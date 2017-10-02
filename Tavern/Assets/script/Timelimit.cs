using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timelimit : MonoBehaviour
{
    public GameObject TimeUpText;
    public GameObject tugiheButton;
    public GameObject tugiheText;

    private float time = 180;


	void Start ()
    {

        GetComponent<Text>().text = ((int)time).ToString();
        TimeUpText.SetActive(false);
        tugiheText.SetActive(false);
	}
	
	void Update ()
    {
        time -= Time.deltaTime;

        if(time < 1)
        {
            StartCoroutine("TimeUp");
            StartCoroutine("tugige");
        }

        //
        if (time < 0) time = 0;
        float fun = (time / 60.0f); //2.9833333
        int intFun = (int)fun; //2
        //
        float intFunFloat = intFun * 1.0f; //2.0f
        float sec = (fun - intFunFloat) * 60.0f; //(2.983333 - 2.0f = 0.983333 ) * 60 = 58.999993
        int intSec = (int)sec; //58
        string secStr = intSec.ToString();
        if (intSec < 10)
        {
            secStr = "0" + secStr;
        }

        GetComponent<Text>().text = intFun.ToString() +":"+ secStr;

    }

    IEnumerator TimeUp()
    {
        TimeUpText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
    }
    IEnumerator tugige()
    {
        tugiheText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
    }
}
