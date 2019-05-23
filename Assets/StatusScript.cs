using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{
    public Text points;
    public Text money;
    public Text kills;
    public Text enemiesLeft;
    public Text wavesLeft;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        points.text = gameManager.GetPoints().ToString();
        money.text = gameManager.GetMoney().ToString();
        kills.text = gameManager.GetKills().ToString();
        enemiesLeft.text = gameManager.GetEnemiesLeft().ToString();
        wavesLeft.text = gameManager.GetWavesLeft().ToString();
    }
}
