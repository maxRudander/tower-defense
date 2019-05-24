using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string t = "";
     
        t = "Your score was:" + PlayerPrefs.GetInt("Score") +" \n\n" +
            "You " + PlayerPrefs.GetString("Result") + "\n" + // won/lost from PlayerPref
            "Creeps killed:" + PlayerPrefs.GetInt("Kills") + "\n" +
            "Creeps escaped:" + PlayerPrefs.GetInt("Escapees");

        this.gameObject.GetComponent<Text>().text = t;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
