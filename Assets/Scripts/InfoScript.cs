using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour {
    private bool done = false;
    private GameObject tower;
    bool wait = true;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //if (!done) {
        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
        //        Debug.Log(hit.point + " ");
        //        tower = hit.transform.gameObject;
        //        //infoPanel.SetActive;




        //        //  towerToAdd.transform.position = hit.point;
        //        //GameObject tower = Instantiate(towerToAdd, towerToAdd.transform.position, Quaternion.identity);
        //        //tower.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", color);
        //        //tower.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_Color", color);
        //        //tower.transform.GetChild(0).transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_Color", color);
        //        //tower.transform.GetChild(0).transform.GetChild(4).GetComponent<Renderer>().material.SetColor("_Color", color);
        //    }
        //}
    }
    public void setDone(bool done) {
        this.done = done;
    }
    public void checkForTower() {
        Debug.Log("Check for tower");
        StartCoroutine(WaitInput(wait, tower));
    }



    public static IEnumerator WaitInput(bool wait, GameObject tower) {
        Debug.Log("In Enum");
        while (wait) {

            if (Input.GetMouseButtonDown(1)) {
                //Debug.Log("In RIGHTBTN");
                yield return null;
            }
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Got mouse 0");
                RaycastHit hit;
                int layerMask = 1 << 11;
                //layerMask = ~layerMask;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask)) {
                    Debug.Log(hit.point + " träffar något?");
                    Debug.Log(hit.transform.gameObject.name);
                    if (hit.transform.gameObject.tag == "Tower") {
                        Debug.Log("Träffff!!!!");
                        tower = hit.transform.gameObject;
                        
                        GameObject infoPanel = tower.transform.GetChild(1).transform.GetChild(0).transform.gameObject;
                        infoPanel.transform.position = tower.transform.position + new Vector3(0.0f, 25.0f, 0.0f);
                        infoPanel.SetActive(true);
                    }
                }
                wait = false;
            }
            yield return null;
        }
    }


}
