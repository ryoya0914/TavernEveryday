using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClosedSerihu : MonoBehaviour
{
    public bool tutorial;
    public bool close;
    public Image kyara;
    public Sprite[] texture;

    public string[] scenarios;
    [SerializeField]
    Text UIText;

    public int[] character;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float IntervelDisplay = 0.05f;

    private string currentText = string.Empty;
    private float timeDisplay = 0;
    private float timeElapsed = 1;
    private int currentLine = 0;
    private int wordCount = -1;
    private bool TouchOk = false;
    private bool endIntro = false;

    public bool CompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeDisplay; }
    }

    void Start()
    {
        if (tutorial == true)
        {
            SetNextLine();
            TouchNo();
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(false);
            TouchYes();
        }
    }

    bool GetIntro()
    {
        return endIntro;
    }

    void Update()
    {
        if (TouchOk == false)
        {
            if (CompleteDisplayText)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!close)
                    {
                        EndConversation();

                        if(tutorial && !endIntro)
                        {
                            if (GameObject.Find("NakamaController").GetComponent<NakamaController>().CharaOK())
                            {
                                StartConversation(7);
                                endIntro = true;
                                tutorial = false;
                            }
                        }
                        
                    }
                    else
                    {
                        //EndConversation();
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    timeDisplay = 0;
                }
            }
            int DisplayConut = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeDisplay) * currentText.Length);
            if (DisplayConut != wordCount && DisplayConut >= 0)
            {
                UIText.text = currentText.Substring(0, DisplayConut);
                wordCount = DisplayConut;
            }
        }

    }


    public void SetNextLine()
    {
        currentText = scenarios[currentLine];
        timeDisplay = currentText.Length * IntervelDisplay;
        timeElapsed = Time.time;

        currentText = currentText.Replace("\\n", "\n");

        wordCount = -1;

        kyara.sprite = texture[character[currentLine]];
    }

    public void SetCurrent(int current)
    {
        currentLine = current;
    }

    public void EndConversation()
    {
        if (GameObject.Find("Panel"))
            GameObject.Find("Panel").SetActive(false);
        TouchYes();
    }

    public void StartConversation(int current)
    {

        timeDisplay = 0;
        timeElapsed = 1;
        currentLine = 0;
        wordCount = -1;

        currentLine = current;

        SetNextLine();

        GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
        TouchNo();
    }


    public void TouchYes()
    {
        TouchOk = true;
        //Debug.Log("yes");
    }
    public void TouchNo()
    {
        TouchOk = false;
        //Debug.Log("no");
    }

    public bool getTouch()
    {
        return TouchOk;
    }
}
