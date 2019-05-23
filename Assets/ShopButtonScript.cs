using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonScript : MonoBehaviour {
    private bool shopActive = false;
    public GameObject towerPanel;

    // Start is called before the first frame update
    void Start() {
     
    }

    // Update is called once per frame
    void Update() {
    
                

    }
    
    public void TogglePanel(GameObject panel) {
        panel.SetActive(!panel.activeSelf);
    }
}
