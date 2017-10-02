using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class IconTouch : MonoBehaviour
{
    public serihu serihu;

    private Money moneyM;

    private bool collided = false;

    private ChibiMove Mc;

    private GameObject bikuri;


    void Start()
    {
        Mc = GameObject.Find("MC chibi").GetComponent<ChibiMove>();

        moneyM = GameObject.Find("roberi").GetComponent<Money>();

        serihu = GameObject.Find("Textcontroller").GetComponent<serihu>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                GameObject obj = collition2d.transform.gameObject;
                if (obj.name == "bikuri(Clone)")
                {

                    if (GameObject.Find("Textcontroller").GetComponent<serihu>().getTouch())
                    {
                        if(serihu.tutorial)
                        {
                            Invoke("CreateIcon4", 3f);
                        }
                        else
                        {
                            Invoke("CreateIcon3", 3f);
                        }
                        if (transform.tag == "table1")
                        {
                            Mc.Mctable1();
                        }
                        else if (transform.tag == "table2")
                        {
                            Mc.Mctable2();
                        }
                        bikuri = obj;
                        bikuri.GetComponent<BoxCollider2D>().enabled = false;
                        bikuri.GetComponent<SpriteRenderer>().enabled = false;

                        if (serihu.tutorial)
                        {
                            GameObject.Find("Textcontroller").GetComponent<serihu>().TouchNo();
                            GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
                        }
                    }
                }

                else if (obj.name == "okaikei(Clone)")
                {
                    if (GameObject.Find("Textcontroller").GetComponent<serihu>().getTouch())
                    {
                        DestroySI(obj);
                        moneyM.Moneypurasu(500);

                        if (serihu.tutorial)
                        {
                            GameObject.Find("Textcontroller").GetComponent<serihu>().TouchNo();
                            GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
                        }

                    }

                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Icon")
        {
            collided = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Icon")
        {
            collided = false;
        }
    }

    void DestroySI(GameObject obj)
    {
        Destroy(obj);
    }

    void CreateIcon3()
    {
        int randam = Random.Range(0, 2);
        GameObject icon;
        if (randam == 0)
        {
            icon = Instantiate(Resources.Load("beerfukidashi"), Vector3.zero, Quaternion.identity) as GameObject;
            transform.parent.GetComponent<MouseTouch>().SetBeer(true);
        }
        else
        {
            icon = Instantiate(Resources.Load("edamamefukudashi"), Vector3.zero, Quaternion.identity) as GameObject;
            transform.parent.GetComponent<MouseTouch>().SetBeer(false);
        }
        var obj_parent = GameObject.Find("Canvas");
        icon.transform.parent = transform.parent;


        StartCoroutine("Destroyicon", icon);

    }

    void CreateIcon4()
    {
        if(serihu.tutorial)
        {
            int randam = Random.Range(0, 2);
            GameObject icon;
            if (randam == 0)
            {
                icon = Instantiate(Resources.Load("beerfukidashi"), Vector3.zero, Quaternion.identity) as GameObject;
                transform.parent.GetComponent<MouseTouch>().SetBeer(true);
            }
            else
            {
                icon = Instantiate(Resources.Load("edamamefukudashi"), Vector3.zero, Quaternion.identity) as GameObject;
                transform.parent.GetComponent<MouseTouch>().SetBeer(false);
            }
            var obj_parent = GameObject.Find("Canvas");
            icon.transform.parent = transform.parent;


            StartCoroutine("Destroyicon", icon);
        }
    }

    IEnumerator Destroyicon(GameObject icon)
    {

        yield return new WaitForSeconds(2f);

        Destroy(icon.gameObject);
        Destroy(bikuri);
    }
}
