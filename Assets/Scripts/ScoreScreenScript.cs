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
        t = "Your score was: \n\n" +
            "Creeps killed:" + "\n" +
            "Score: " + "\n" +
            "Gold gained: " + "\n";
       
             this.gameObject.GetComponent<Text>().text = t;

        // Should use PlayerPrefs.Get....
        // This requires that we save the scores etc before we leave the primary game scene -> load in this scene

        // var myVariable : float;
        //PlayerPrefs.SetFloat("Player Score", 10.0);
        //myVariable = PlayerPrefs.GetFloat("Player Score");
        //print(myVariable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
