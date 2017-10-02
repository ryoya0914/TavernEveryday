using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{

	void Start ()
    {
        var text = GameObject.Find("goukei").GetComponent<Text>().text = PlayerPrefs.GetInt("money",0).ToString();
        PlayerPrefs.GetInt("goukei",0);
        int goukei = PlayerPrefs.GetInt("goukei", 0);
        goukei += PlayerPrefs.GetInt("money", 0);
        PlayerPrefs.SetInt("goukei", goukei);
        PlayerPrefs.SetInt("money", 0);
    }
	

	void Update ()
    {
	
	}
}
