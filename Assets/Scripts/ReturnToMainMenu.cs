using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public bool IsMainMenu = false;

    public void ButtonMapOne()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}



