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
        points.text = gameManager.Score.ToString();
        money.text = gameManager.Money.ToString();
        kills.text = gameManager.NbrOfKills.ToString();
        enemiesLeft.text = gameManager.MobsLeftInWave.ToString();
        wavesLeft.text = gameManager.WavesLeft.ToString();
    }
}
