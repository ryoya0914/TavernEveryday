using UnityEngine;
using System.Collections;

public class otumamiTouch : MonoBehaviour
{
    private GameObject Table;

    private SpriteRenderer spRenderer;
    private Vector3 startpos;
    private new Rigidbody2D rigidbody;
    private MouseTouch Salaryman;

    private bool collided = false;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startpos = transform.position;
        spRenderer = GetComponent<SpriteRenderer>();



    }
	
	void Update () {
	
	}

    void OnMouseDrag()
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

    void OnMouseUp()
    {
            if (collided == true)
            {
                Vector3 chairpos = Table.transform.position;

                bool beer = true;
                
                chairpos.y -= 0.5f;
                chairpos.x += 0.9f;

                if (transform.tag == "edamame")
                {
                    chairpos.y -= 0.5f;
                    chairpos.x += 0.1f;

                beer = false;
                }

                rigidbody.position = chairpos;

                Table.GetComponent<MouseTouch>().BeerGet(beer);
            }
            if (collided == false)
            {
                transform.position = startpos;
            }
            var color = spRenderer.color;
            color.a = 1f;
            spRenderer.color = color;



    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "SalarymanSit")
        {
            collided = true;

            Table = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "SalarymanSit")
        {
            collided = false;
        }
    }
}
