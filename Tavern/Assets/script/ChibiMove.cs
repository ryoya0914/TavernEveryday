using UnityEngine;
using System.Collections;

public class ChibiMove : MonoBehaviour
{
    public Counter Barcounter;
    public serihu serihu;

    private bool collided;

    public void Mctable1()
    {
        transform.FollowPath("Mctable1", 5f, Mr1.FollowType.Once);
    }

    public void Mctable2()
    {
        transform.FollowPath("Mctable2", 5f, Mr1.FollowType.Once);
    }

    public void Mc2Follow()
    {
        transform.FollowPath("Mc2", 5f, Mr1.FollowType.Once);
        Invoke("Mc3Follow",2f);
    }

    private void Mc3Follow()
    {
        transform.FollowPath("Mc3", 5f, Mr1.FollowType.Once);
    }

    public void Mc4Follw()
    {
        transform.FollowPath("Mc4", 5f, Mr1.FollowType.Once);
        Invoke("Mc5Follow", 4f);
    }

    public void Mc5Follow()
    {

            if (GameObject.Find("Textcontroller").GetComponent<serihu>().getTouch())
            {
                transform.FollowPath("Mc5", 5f, Mr1.FollowType.Once);

            if (serihu.tutorial)
            {
                GameObject.Find("Textcontroller").GetComponent<serihu>().TouchNo();
                GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Barcounter")
        {
            Barcounter.nagisafollow();
        }
    }
}
