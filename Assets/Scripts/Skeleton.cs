using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
   public int hpMax;
   public int hpCurrent;
   public int level;

   public int movementSpeed = 25;

   public float currentMovementSpeed;

   public float slowDuration;
   
   public bool isSlowed;

   public GameObject lastBulletHit;

   void Start()
   {
       currentMovementSpeed = movementSpeed;
       this.gameObject.GetComponent<NavMeshAgent>().speed = movementSpeed;
   }

   public void SetHpBasedOnLevel(int level)
   {
       hpMax = hpMax * level;
       hpCurrent = hpMax;
   }

   public void setGoal(GameObject goal)
   {
       this.gameObject.GetComponent<NavMeshAgent>().SetDestination(goal.GetComponent<Transform>().position);
   }

   // Update is called once per frame
   void Update()
   {
       Animator an = this.gameObject.GetComponent<Animator>();
       an.SetBool("Running", true);

        if(currentMovementSpeed != movementSpeed){
            isSlowed = true;
            slowDuration -= Time.deltaTime;
            Debug.Log(slowDuration);
            if(slowDuration < 0){
                currentMovementSpeed = movementSpeed;
                isSlowed = false;
                this.gameObject.GetComponent<NavMeshAgent>().speed = movementSpeed;
                slowDuration = 1;
            }
        }


       if(hpCurrent <= 0){
           lastBulletHit.GetComponent<bulletTower>().updateTowerKills();
           Destroy(gameObject);
       }
   }

   
}