using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerUpgradeScript : MonoBehaviour
{
    public Button button;

    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(upgrade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgrade(){
        tower.gameObject.GetComponent<Tower>().upgradeTower();
    }
}
