using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMainMenu : MonoBehaviour
{
    public bool IsMainMenu = false;

    public void ButtonMapOne()
    {
        //SceneManager.LoadScene("MainMenuScene"); // Or (1) i.e. position in build
        Debug.Log("Map 1 button method");
        //GetComponent<Renderer>().material.color = Color.cyan;
    }
}



