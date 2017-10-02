using UnityEngine;
using System.Collections;

public class Generation : MonoBehaviour
{
    public GameObject GenerationChoice;
    int createCounter;
    float timer;
    public int Createkyara;
    public float CreateTime;

    private GameObject[] CustomerLine = new GameObject[6];

    void Start()
    {
        createCounter = 0;
        timer = 0;

        for(int i = 0; i < 6; i++)
        {
            CustomerLine[i] = null;
        }
    }

    void Update()
    {
        for(int i = 0; i< 6; i++)
        {
            if(CustomerLine[i])
            {
                if (CustomerLine[i].name != "Salaryman")
                {
                    CustomerLine[i] = null;
                }
            }  
        }
        if (createCounter < Createkyara)//10個生成していない時
        {
            timer += Time.deltaTime;
            if (timer >= 2)//２秒経過した時
            {
                for (int i = 0; i < 6; i++)
                {
                    if(CustomerLine[i] == null)
                    {
                        timer -= CreateTime;
                        var Salaryman= Instantiate(GenerationChoice) as GameObject;
                        Salaryman.name = "Salaryman";
                        Salaryman.transform.position = new Vector3(-7.5f + 2 * (i % 2), -3.9f + 2 * (i - (i %2)) / 2, 0.0f);
                        CustomerLine[i] = Salaryman;
                        createCounter++;
                        return;
                    }
                }

            }

        }
    }
}
