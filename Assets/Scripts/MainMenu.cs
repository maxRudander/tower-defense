using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStartMap1 = false;
    public bool isStartMap2 = false;
    public bool isExit = false;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonMapOne()
    {
		SceneManager.LoadScene("RoosScene"); // Or (1) i.e. position in build
        Debug.Log("Map 1 button method");
        //GetComponent<Renderer>().material.color = Color.cyan;
    }

    public void ButtonMapTwo()
    {
        Debug.Log("Map 2 button method");  
    }

    public void ButtonExit()
    {
        Debug.Log("Exit button method");
        Application.Quit();
    }

}
