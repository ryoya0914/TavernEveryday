using UnityEngine;
using System.Collections;

public class Gomibako : MonoBehaviour
{
    public serihu serihu;

	void Start () {
	
	}
	

	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D hit)
    {
                if (hit.CompareTag("beer"))
                {
                    Destroy(hit.gameObject);
                }

                if (hit.CompareTag("edamame"))
                {
                    Destroy(hit.gameObject);
                }
    }
}
