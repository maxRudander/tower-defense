using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPanelScript : MonoBehaviour
{

    public GameObject cannonTowerButton;
    public GameObject fireTowerButton;
    public GameObject iceTowerButton;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.Money < 10) {
            cannonTowerButton.SetActive(false);
        } else {
            cannonTowerButton.SetActive(true);
        }
        if (gameManager.Money < 20) {
            fireTowerButton.SetActive(false);

        } else {
            fireTowerButton.SetActive(true);
        }
        if (gameManager.Money < 50) {
            iceTowerButton.SetActive(false);
        } else {
            iceTowerButton.SetActive(true);
        }

    }

}
