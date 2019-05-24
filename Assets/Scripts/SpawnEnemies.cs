using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject skeleton;
    public GameObject goal = null;

    public GameObject folder;
    public GameManager gm;
    public int numberOfSkeletonsToSpawn = 10;
    private int nbrOfSpawnedSkeletons;
    private bool spawnActive;
    List<Level> levels;

    private bool waiting;

    private int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectsOfType<GameManager>()[0];
        
        nbrOfSpawnedSkeletons = 0;
        spawnActive = true;
        levels = new List<Level>();
        levels.Add(new Level()
        {
            id = 1,
            nbrOfMobs = 10,
            mobHp = 100,
            mobSpeed = 100
        });
        levels.Add(new Level()
        {
            id = 2,
            nbrOfMobs = 10,
            mobHp = 200,
            mobSpeed = 100
        });
        levels.Add(new Level()
        {
            id = 3,
            nbrOfMobs = 10,
            mobHp = 100,
            mobSpeed = 100
        });

        gm.WavesLeft = levels.Count;
        gm.MobsLeftInWave = levels[0].nbrOfMobs;
        numberOfSkeletonsToSpawn = gm.MobsLeftInWave;
        waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.N))
        if (spawnActive)
        {
            waiting = false;
            InvokeRepeating("spawnSkeletons", 0.0f, 0.5f);
            spawnActive = false;
        }
        else if (gm.MobsLeftInWave < 1 && !waiting)
        {
            waiting = true;
            Invoke("nextWave", 5.0f);
        }
    }

    void spawnSkeletons()
    {
        var obj = Instantiate(skeleton, transform.position, Quaternion.identity);
        obj.GetComponent<Skeleton>().setGoal(goal);
        obj.GetComponent<Skeleton>().hpMax = levels[currentLevel].mobHp;
        obj.GetComponent<Skeleton>().hpCurrent = levels[currentLevel].mobHp;
        obj.GetComponent<Skeleton>().level = levels[currentLevel].id;
        obj.GetComponent<Skeleton>().movementSpeed = levels[currentLevel].mobSpeed;

        nbrOfSpawnedSkeletons++;
        if (nbrOfSpawnedSkeletons >= numberOfSkeletonsToSpawn)
        {
            CancelInvoke("spawnSkeletons");
            //nbrOfSpawnedSkeletons = 0;
        }
    }

    void nextWave()
    {
        if (gm.WavesLeft > 0)
        {
            currentLevel++;
            gm.WaveCleared();

            //gm.WavesLeft = levels.Count - currentLevel;
            gm.MobsLeftInWave = levels[currentLevel].nbrOfMobs;
            numberOfSkeletonsToSpawn = numberOfSkeletonsToSpawn + gm.MobsLeftInWave;
            spawnActive = true;
        }
        else
        {
            //Victory!!
        }
    }

     public class Level{
       public int id;
        public int nbrOfMobs;
        public int mobHp;
        public int mobSpeed;
   }
}