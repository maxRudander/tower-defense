using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.mousePosition.x > Screen.width - 10 || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.mousePosition.x < 10 || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.mousePosition.y > Screen.height - 10 || Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, Mathf.Cos(speed * Time.deltaTime),speed * Time.deltaTime));
        }
        if (Input.mousePosition.y < 10 || Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -Mathf.Sin(speed * Time.deltaTime), -speed * Time.deltaTime));
        }
        if (Input.GetMouseButton(2))
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(0.0f, speed * Time.deltaTime, -Mathf.Cos(speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(0.0f, -speed * Time.deltaTime, Mathf.Cos(speed * Time.deltaTime));
            }
        }
    }
}

