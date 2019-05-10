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
    private GameObject[] goals;

    // Start is called before the first frame update
    void Start()
    {
        goals = new GameObject[5];
        goals[0] = goal1;
        goals[1] = goal2;
        goals[2] = goal3;
        goals[3] = goal4;
        goals[4] = goal5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           var obj = Instantiate(skeleton, transform.position, Quaternion.identity);
           obj.GetComponent<Skeleton>().setGoal(goals);

            //skeleton.GetComponent<>()

            //    setGoal(goal1);

        }
    }
}
