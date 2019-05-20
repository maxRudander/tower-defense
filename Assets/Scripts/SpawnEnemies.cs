using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject skeleton;
    public GameObject goal1 = null;
    public GameObject goal2 = null;
    public GameObject goal3 = null;
    public GameObject goal4 = null;
    public GameObject goal5 = null;
    public GameObject goal6 = null;
    public GameObject goal7 = null;
    public GameObject goal8 = null;
    public int numberOfSkeletonsToSpawn = 10;
    private int nbrOfSpawnedSkeletons;
    private GameObject[] goals;

    // Start is called before the first frame update
    void Start()
    {
        goals = new GameObject[8];
        goals[0] = goal1;
        goals[1] = goal2;
        goals[2] = goal3;
        goals[3] = goal4;
        goals[4] = goal5;
        goals[5] = goal6;
        goals[6] = goal7;
        goals[7] = goal8;
        nbrOfSpawnedSkeletons = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            InvokeRepeating("spawnSkeletons", 0.0f, 0.5f);
        }
    }

    void spawnSkeletons()
    {
        var obj = Instantiate(skeleton, transform.position, Quaternion.identity);
        obj.GetComponent<Skeleton>().setGoal(goals);
        nbrOfSpawnedSkeletons++;
        if (nbrOfSpawnedSkeletons >= numberOfSkeletonsToSpawn)
        {
            CancelInvoke("spawnSkeletons");
            nbrOfSpawnedSkeletons = 0;
        }
    }
}
