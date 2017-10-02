using UnityEngine;
using System.Collections;

public class Pousemenu : MonoBehaviour
{
    public serihu pouse;

	void Start ()
    {

	}
	

	void Update ()
    {

	}

    public void pusepanel()
    {
        transform.gameObject.SetActive(true);
    }

    public void OptionButton()
    {
        transform.gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("pausemenu").gameObject.SetActive(false);
    }

    public void ReturnButton()
    {
        GameObject.Find("Canvas").transform.Find("pausemenu").gameObject.SetActive(false);
    }

    public void ReturnButton2()
    {
        GameObject.Find("Canvas").transform.Find("optionmenu").gameObject.SetActive(false);

    }
}
