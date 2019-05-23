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
   private boolean spawnActive;

   // Start is called before the first frame update
   void Start()
   {
       gm = GameObject.FindObjectsOfType<GameManager>()[0];
	   numberOfSkeletonsToSpawn = gm.MobsLeftInWave;
	   nbrOfSpawnedSkeletons = 0;
	   spawnActive = true;
   }

   // Update is called once per frame
   void Update()
   {
       //if (Input.GetKeyDown(KeyCode.N))
	   if (spawnActive)
       {
           InvokeRepeating("spawnSkeletons", 0.0f, 0.5f);
       }

	   else
	   {
	   	   Invoke("nextWave", 5.0f);
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
		   spawnActive = false;
           //nbrOfSpawnedSkeletons = 0;

       }
   }

   void nextWave()
   {
   	   if (gm.WavesLeft > 0)
	   {
	   	   nbrOfSpawnedSkeletons = gm.MobsLeftInWave;
		   spawnActive = true;
	   }
	   else
	   {
	   	   //Victory!!
	   }
   }
}