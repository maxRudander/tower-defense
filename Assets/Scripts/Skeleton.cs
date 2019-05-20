using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
   public int hpMax;
   public int hpCurrent;
   public int level;

   // Start is called before the first frame update
   void Start()
   {

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

   }
}