using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject TowerPrefab { get => TowerPrefab; set => TowerPrefab = value; }
    private int money;
	private int nbrOfKills;
	private int nbrOfEscapes;
	private int score;
	private int mobsLeftInWave;
	private int wavesLeft;





	public int Money
	{
		get { return money; }
		set { money = value; }
	}

	public int NbrOfKills
	{
		get { return nbrOfKills; }
		set { nbrOfKills = value; }
	}

	public int NbrOfEscapes
	{
		get { return nbrOfEscapes; }
		set { nbrOfEscapes = value; }
	}

	public int Score
	{
		get { return score; }
		set { score = value; }
	}

	public int MobsLeftInWave
	{
		get { return mobsLeftInWave; }
		set { mobsLeftInWave = value; }
	}

	public int WavesLeft
	{
		get { return wavesLeft; }
		set { wavesLeft = value; }
	}

	public void ModifyMoney (int change)
	{
		if ((money - change) >= 0 ) money = money+change;
	}

	void IncreaseScore (int points)
	{
		if (points > 0) score = score + points;
	}

	public void ReportKill ()
	{
		nbrOfKills = nbrOfKills + 1;
		if (mobsLeftInWave > 0) mobsLeftInWave = mobsLeftInWave - 1;
		//if (mobsLeftInWave < 1) WaveCleared();
	}

	public void ReportEscape ()
	{
		Debug.Log("Report" + nbrOfEscapes);
		nbrOfEscapes = nbrOfEscapes + 1;
		if (nbrOfEscapes >= 5) GameOver(false); // DEFEAT!! & return (remove hardcoded five)
		else
		{
			if (mobsLeftInWave > 0) mobsLeftInWave = mobsLeftInWave - 1;
			//if (mobsLeftInWave < 1) WaveCleared();
		}

	}

	public void WaveCleared()
	{
		if (wavesLeft < 1) GameOver(true); // WIN!! & return
		else 
		{
			wavesLeft = wavesLeft - 1;
			mobsLeftInWave = (6 - wavesLeft)*10;
		}
		// set difficulty for next wave

	}

	void GameOver(bool won)
	{
		Debug.Log("Fail");
		string res;
		if (won) res = "Won";
		else res = "Lost";
		PlayerPrefs.SetString("Result", res);
		PlayerPrefs.SetInt("Kills", nbrOfKills);
		PlayerPrefs.SetInt("Escapees", nbrOfEscapes);

		SceneManager.LoadScene("ScoreScene");
	}
    // Start is called before the first frame update
    void Start()
    {
        money = 100;
		mobsLeftInWave = 10;
		wavesLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
