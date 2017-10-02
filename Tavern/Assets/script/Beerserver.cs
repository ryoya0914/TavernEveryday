using UnityEngine;
using System.Collections;

public class Beerserver : MonoBehaviour
{
    public GameObject beer;

    private bool collided = false;

    private ChibiMove Mc;

    void Start ()
    {
        Mc = GameObject.Find("MC chibi").GetComponent<ChibiMove>();
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {

                Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);

                if (collition2d)
                {
                    GameObject obj = collition2d.transform.gameObject;
                    if (obj.name == "Beer server")
                    {
                        Mc.Mc4Follw();
                        Invoke("Beerputout", 4f);
                    }
                }
            }

    }

    void Beerputout()
    {
        var nomimono = Instantiate(beer, new Vector3(transform.position.x + 0.1f, transform.position.y - 1f), Quaternion.identity) as GameObject;
        nomimono.tag = "beer";
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Beer server")
        {
            collided = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Beer server")
        {
            collided = false;
        }
    }
}
