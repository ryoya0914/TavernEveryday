using UnityEngine;
using System.Collections;

public class MouseTouch : MonoBehaviour
{
    Animator animator;
    
    private GameObject chair;
    public GameObject icon;
    public GameObject icon2;

    public serihu serihu;

    private bool beer = true;

    //あったってる
    private bool collided = false;
    private bool right = true;
    private bool sitdown = false;
    private bool otumami = true;

    private new Rigidbody2D rigidbody;
    private Vector3 startpos;
    private SpriteRenderer spRenderer;

    [SerializeField]
    private GameObject HpBar;
    private float hp = 100;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startpos = transform.position;
        spRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        serihu = GameObject.Find("Textcontroller").GetComponent<serihu>();
    }

    //キャラのHP管理
    void Update()
    {
        if(serihu.tutorial)
        {
            var scale = HpBar.transform.position;
            scale.x = ((float)hp / (float)100);
            scale.y = 1;
            HpBar.transform.localScale = scale;
        }
        else
        {
            var scale = HpBar.transform.position;
            scale.x = ((float)hp / (float)110);
            scale.y = 1;
            HpBar.transform.localScale = scale;

            hp -= 3 * Time.deltaTime;


            if(hp <=0)
            {
                if(transform.name =="Salaryman")
                {
                    animator.SetBool("Angry", true);
                }
                if (transform.name == "SalarymanSit")
                {
                    animator.SetBool("Angry", true);

                }
            }
            if (hp <= 10)
            {
                transform.name = "Salary";
                Invoke("DestroySalaryman", 2.0f);
            }
        }

    }

    void DestroySalaryman()
    {
        Destroy(transform.gameObject);
    }

    void OnMouseDrag()
    {
        if (GameObject.Find("Textcontroller").GetComponent<serihu>().getTouch())
        {
                if (!sitdown)
            {
                Vector3 objectPointInScreen
                    = Camera.main.WorldToScreenPoint(this.transform.position);

                Vector3 mousePointInScreen
                    = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPointInScreen.z);

                Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
                mousePointInWorld.z = this.transform.position.z;
                this.transform.position = mousePointInWorld;

                var color = spRenderer.color;
                color.a = 0.5f;
                spRenderer.color = color;
            }
        }

    }

    void OnMouseUp()
    {
        if (GameObject.Find("Textcontroller").GetComponent<serihu>().getTouch())
        {
            if (collided == true && sitdown == false)
            {
                Vector3 chairpos;
                chairpos = chair.transform.position;
                chairpos.y += 0.8f;
                rigidbody.position = chairpos;

                sitdown = true;

                animator.SetBool("sit", true);

                Invoke("CreateIcon", 3f);
                transform.name = "SalarymanSit";
                if (serihu.tutorial)
                {
                    GameObject.Find("Textcontroller").GetComponent<serihu>().TouchNo();
                    GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
                }
            }

            if (collided == false && sitdown == false)
            {
                transform.position = startpos;
            }
            var color = spRenderer.color;
            color.a = 1f;
            spRenderer.color = color;
        }

      }

    public void SetBeer(bool beerBool)
    {
        beer = beerBool;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "chair1")
        {
            transform.tag = "table1";
            collided = true;

            chair = other.gameObject;
            if(chair.tag == "right")
            {
                right = true;
                Vector3 lscale = transform.localScale;
                if(lscale.x <= 0)
                {
                    lscale.x = -lscale.x;
                }
                
                transform.localScale = lscale;
            }
            else
            {
                right = false;

                Vector3 lscale = transform.localScale;
                if (lscale.x >= 0)
                {
                    lscale.x *= -1;
                }
                transform.localScale = lscale;

            }
        }
        if (other.gameObject.name == "chair2")
        {
            transform.tag = "table2";
            collided = true;

            chair = other.gameObject;
            if (chair.tag == "right")
            {
                right = true;
                Vector3 lscale = transform.localScale;
                if (lscale.x <= 0)
                {
                    lscale.x = -lscale.x;
                }

                transform.localScale = lscale;
            }
            else
            {
                right = false;

                Vector3 lscale = transform.localScale;
                if (lscale.x >= 0)
                {
                    lscale.x *= -1;
                }
                transform.localScale = lscale;

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "chair1")
        {
            collided = false;
        }
        if (other.gameObject.name == "chair2")
        {
            collided = false;
        }

    }

    //bikuriの生成
    void CreateIcon()
    {
            var bikuri = Instantiate(icon, new Vector3(transform.position.x + 1.5f, transform.position.y + 1f, 0), Quaternion.identity) as GameObject;
            bikuri.tag = transform.tag;
            bikuri.transform.parent = transform;
     }
    //ビールがあったら
    public void BeerGet(bool beerBool)
    {
        if(beerBool == beer)
        {
            Invoke("CreateIcon2", 7f);
        }
        else
        {
            hp -= 20;
            hp = Mathf.Clamp(hp, 0, 100);
        }


    }

    void CreateIcon2()
    {
                GameObject icon = (GameObject)Instantiate(icon2, new Vector3(transform.position.x + 1.5f, transform.position.y + 1f), Quaternion.identity);
            //icon.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            icon.transform.parent = transform;
    }
}