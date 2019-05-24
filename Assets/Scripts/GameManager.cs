using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject TowerPrefab { get => TowerPrefab; set => TowerPrefab = value; }
    public int money;
	private int nbrOfKills;
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

	void ReportKill ()
	{
		nbrOfKills = nbrOfKills + 1;
		if (mobsLeftInWave > 0) mobsLeftInWave = mobsLeftInWave - 1;
		if (mobsLeftInWave < 1) WaveCleared();
	}

	void WaveCleared()
	{
		if (wavesLeft < 1) return; // WIN!! & return
		else wavesLeft = wavesLeft - 1;
		// set difficulty for next wave
	}
    // Start is called before the first frame update
    void Start()
    {
		mobsLeftInWave = 10;
		wavesLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
