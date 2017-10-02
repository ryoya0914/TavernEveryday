using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour
{
    public float speed = 2;
    Vector2 vec;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(vec.x, vec.y), speed * Time.deltaTime);
    }
}