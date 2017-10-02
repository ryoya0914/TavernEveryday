using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class callmain : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CallScene());
    }
    IEnumerator CallScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("main");
    }
}
