using UnityEngine;
using System.Collections;

public class ConterTouch : MonoBehaviour
{
    private ChibiMove Mc;

	void Start ()
    {
        Mc = GameObject.Find("MC chibi").GetComponent<ChibiMove>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if(collition2d)
            {
                if (collition2d.gameObject.transform == transform)
                {
                    Mc.Mc2Follow();
                }
            }

        }
    }
}
