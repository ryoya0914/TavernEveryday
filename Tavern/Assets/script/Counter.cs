using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour 
{
    public GameObject rice;
    public serihu serihu;

    public void nagisafollow()
    {
        transform.FollowPath("nagisa", 3.5f, Mr1.FollowType.PingPong);
        Invoke("stopdayo",12f);
    }
    
    void stopdayo()
    {
        transform.StopFollowing();
        Invoke("riceputout", 2f);

    }

    void riceputout()
    {
                var otumami = Instantiate(rice, new Vector3(transform.position.x + 0.18f, transform.position.y - 1f), Quaternion.identity) as GameObject;
            otumami.tag = "edamame";
    }
}
