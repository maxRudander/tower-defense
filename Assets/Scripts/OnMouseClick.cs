using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
        
    }

    void OnMouseDown(){
   // this object was clicked - do something

    this.gameObject.transform.parent.parent.localScale += new Vector3(0.05f, 0.05f, 0.05f);

    Debug.Log(this.gameObject.transform.parent.parent.GetChild(1).GetChild(1).GetComponent<FirstTryShooting>().cooldown = 0.1f);
    
    
 }

    // Update is called once per frame
    void Update()
    {
        
    }
}