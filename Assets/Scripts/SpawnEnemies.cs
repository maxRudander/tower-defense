using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
   public GameObject skeleton;
   public GameObject goal = null;
   public int numberOfSkeletonsToSpawn = 10;
   private int nbrOfSpawnedSkeletons;

   // Start is called before the first frame update
   void Start()
   {
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
       obj.GetComponent<Skeleton>().setGoal(goal);
       nbrOfSpawnedSkeletons++;
       if (nbrOfSpawnedSkeletons >= numberOfSkeletonsToSpawn)
       {
           CancelInvoke("spawnSkeletons");
           nbrOfSpawnedSkeletons = 0;
       }
   }
}