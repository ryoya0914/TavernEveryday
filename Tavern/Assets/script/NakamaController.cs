using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NakamaController : MonoBehaviour
{
    [SerializeField]
    private ClosedSerihu serifu;

    private bool[] CharaCheck = new bool[6];

    public bool CharaOK()
    {
        bool ok = true;
        for (int i = 0; i < 6; i++)
        {
            if(CharaCheck[i] == false)
            {
                ok = false;
            }
        }

        return ok;
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            CharaCheck[i] = false;
        }

        GameObject.Find("money").GetComponent<Text>().text = PlayerPrefs.GetInt("goukei",0).ToString();
    }
	// Update is called once per frame
	void Update () {
        if(!serifu.getTouch())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                GameObject obj = collition2d.transform.gameObject;
                if (obj.name == "FumitoC")
                {
                    
                    if(serifu.tutorial)
                    {
                        CharaCheck[0] = true;
                        serifu.StartConversation(1);
                    }
                    else
                    {
                        var randSerihu = Random.Range(0, 3);
                        serifu.StartConversation(8 + randSerihu);
                    }
                    
                }
                else if (obj.name == "IcchiC")
                {
                    if (serifu.tutorial)
                    {
                        CharaCheck[1] = true;
                        serifu.StartConversation(2);
                    }
                    else
                    {
                        var randSerihu = Random.Range(0, 3);
                        serifu.StartConversation(11 + randSerihu);
                    }
                }
                else if (obj.name == "KathyC")
                {
                    if (serifu.tutorial)
                    {
                        CharaCheck[2] = true;
                        serifu.StartConversation(3);
                    }
                    else
                    {
                        var randSerihu = Random.Range(0, 3);
                        serifu.StartConversation(14 + randSerihu);
                    }
                }
                else if (obj.name == "NagisaC")
                {
                    if (serifu.tutorial)
                    {
                        CharaCheck[3] = true;
                        serifu.StartConversation(4);
                    }
                    else
                    {
                        var randSerihu = Random.Range(0, 3);
                        serifu.StartConversation(17 + randSerihu);
                    }
                }
                else if (obj.name == "OkabeC")
                {
                    if (serifu.tutorial)
                    {
                        CharaCheck[4] = true;
                        serifu.StartConversation(5);
                    }
                    else
                    {
                        var randSerihu = Random.Range(0, 3);
                        serifu.StartConversation(20 + randSerihu);
                    }
                }

                else if (obj.name == "MioC")
                {
                    if (serifu.tutorial)
                    {
                        CharaCheck[5] = true;
                        serifu.StartConversation(6);
                    }
                    else
                    {
                        var randSerihu = Random.Range(0, 3);
                        serifu.StartConversation(23 + randSerihu);
                    }
                }
            }
        }
    }
}
