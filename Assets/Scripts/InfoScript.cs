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

    }
    public void setDone(bool done) {
        this.done = done;
    }
    public void checkForTower() {
        Debug.Log("hejsa");
        GameObject[] go = GameObject.FindGameObjectsWithTag("InfoTag");
        for(int i = 0; i < go.Length; i++){
            go[i].transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("hejsa" +i);
        }
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
                        infoPanel.transform.position = tower.transform.position + new Vector3(0.0f, 50.0f, 0.0f); //TEST
                        infoPanel.transform.GetChild(3).transform.gameObject.GetComponent<Text>().text = tower.gameObject.GetComponent<Tower>().kills.ToString();
                        infoPanel.transform.GetChild(4).transform.gameObject.GetComponent<Text>().text = tower.gameObject.GetComponent<Tower>().towerLevel.ToString();
                        infoPanel.SetActive(true);
                    }
                }
                wait = false;
            }
            yield return null;
        }
    }


}
