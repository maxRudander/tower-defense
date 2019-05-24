using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerUpgradeScript : MonoBehaviour
{
    public Button button;

    public Button sellButton;

    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(upgrade);
        sellButton.onClick.AddListener(sell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgrade(){
        tower.gameObject.GetComponent<Tower>().upgradeTower();
    }

    public void sell(){
        GameManager gm = GameObject.FindObjectsOfType<GameManager>()[0];
        int level = tower.GetComponent<Tower>().towerLevel;
        int price = tower.GetComponent<Tower>().price;
        int money = (int)level*(price+price*level)/4;
        gm.ModifyMoney(money);
        Destroy(tower);
    }
}
