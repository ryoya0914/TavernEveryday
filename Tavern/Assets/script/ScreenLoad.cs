using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenLoad : MonoBehaviour
{

    public void SceneLoad()
    {

        SceneManager.LoadScene("tutorial");

    }

    public void SceneLoad2()
    {
        SceneManager.LoadScene("callmain");
    }

    public void ScenLoad3()
    {
        SceneManager.LoadScene("option");
    }

    public void result()
    {

        SceneManager.LoadScene("callmain");

    }

    public void result2()
    {
        SceneManager.LoadScene("cosed");
    }

    public void kextuka()
    {
        PlayerPrefs.SetInt("money", GameObject.Find("roberi").GetComponent<Money>().GetMoney());
        //PlayerPrefs.SetInt("otumamimoney", GameObject.Find("roberi").GetComponent<Money>().GetMoney());
        //PlayerPrefs.SetInt("nomimonomoney", GameObject.Find("roberi").GetComponent<Money>().GetMoney());
        SceneManager.LoadScene("result");

    }

    public void kextuka2()
    {
        PlayerPrefs.SetInt("money", GameObject.Find("roberi").GetComponent<Money>().GetMoney());
        SceneManager.LoadScene("result2");
    }

    public void ReturnScene()
    {
        SceneManager.LoadScene("start");
    }

    public void skipScene()
    {
        PlayerPrefs.SetInt("money", GameObject.Find("roberi").GetComponent<Money>().GetMoney());
        SceneManager.LoadScene("result");
    }
    public void skipScene2()
    {
        PlayerPrefs.SetInt("money", GameObject.Find("roberi").GetComponent<Money>().GetMoney());
        SceneManager.LoadScene("result2");
    }

    public void cosed()
    {
        SceneManager.LoadScene("cosed");
    }

    public void store()
    {
        SceneManager.LoadScene("store");
    }
}
