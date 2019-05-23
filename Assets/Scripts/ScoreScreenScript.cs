using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //this.gameObject.GetComponent<NavMeshAgent>().speed = movementSpeed;


        string t = "";
        t = "Your score was: \n\n" +
            "Creeps killed:" + "\n" +
            "Score: " + "\n" +
            "Gold gained: " + "\n";
       
             this.gameObject.GetComponent<Text>().text = t;

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
