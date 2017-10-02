using UnityEngine;
using System.Collections;

public class CharacterConversation : MonoBehaviour
{
    public serihu serihu;

    void Start ()
    {
	
	}


    void Update()
    {
        if(Input.GetMouseButtonDown(0)&& serihu.getTouch())
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                GameObject obj = collition2d.transform.gameObject;
                if (obj.name == transform.name)
                {
                    serihu.TouchNo();
                    GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);

                    serihu.SetCurrent(1);
                }
            }
         }
    }

}
