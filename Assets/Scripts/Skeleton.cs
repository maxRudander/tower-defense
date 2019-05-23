using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{

    public Slider slider;
    public int hpMax;
    public int hpCurrent;
    public int level;

    public int movementSpeed = 25;

    public float currentMovementSpeed;

    public float slowDuration;

    public bool isSlowed;

    public GameObject lastBulletHit;

    public float distanceToDestination;

    public float deathTime = 5.0f;

    public bool isDead = false;

    void Start()
    {
        currentMovementSpeed = movementSpeed;
        this.gameObject.GetComponent<NavMeshAgent>().speed = movementSpeed;
        slider.maxValue = hpMax;
        slider.minValue = 0;
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

        if (currentMovementSpeed != movementSpeed)
        {
            isSlowed = true;
            slowDuration -= Time.deltaTime;
            Debug.Log(slowDuration);
            if (slowDuration < 0)
            {
                currentMovementSpeed = movementSpeed;
                isSlowed = false;
                this.gameObject.GetComponent<NavMeshAgent>().speed = movementSpeed;
                slowDuration = 1;
            }
        }

        slider.value = hpCurrent;


        if (hpCurrent <= 0 && !isDead)
        {
            lastBulletHit.GetComponent<bulletTower>().updateTowerKills();
            isDead = true;
        }

        if (isDead)
        {
            this.gameObject.GetComponent<NavMeshAgent>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            this.gameObject.GetComponent<NavMeshAgent>().radius = 0;
            an.Play("Death");
            deathTime -= Time.deltaTime;
        }




        if (this.gameObject.GetComponent<NavMeshAgent>().velocity.sqrMagnitude < 1)
        {
            DestroyNearestTower();
        }


        calculateDistance();

        if (distanceToDestination < 1)
        {
            reachedDestination();
        }

        if (isDead && deathTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void DestroyNearestTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        GameObject nearestTower = null;
        float distance = Mathf.Infinity;

        for (int i = 0; i < towers.Length; i++)
        {
            float currentDistance = Vector3.Distance(gameObject.transform.position, towers[i].transform.position);
            if (nearestTower == null || currentDistance < distance)
            {
                nearestTower = towers[i];
                distance = currentDistance;
            }
        }

        if (Vector3.Distance(gameObject.transform.position, nearestTower.transform.position) < nearestTower.GetComponent<NavMeshObstacle>().radius + 2)
        {
            Destroy(nearestTower);
        }
    }

    private void reachedDestination()
    {
        Destroy(gameObject);
    }

    private void calculateDistance()
    {
        NavMeshPath path = new NavMeshPath();

        this.gameObject.GetComponent<NavMeshAgent>().CalculatePath(this.gameObject.GetComponent<NavMeshAgent>().destination, path);

        Debug.Log(this.gameObject.GetComponent<NavMeshAgent>().velocity);



        distanceToDestination = 0;
        for (int j = 1; j < path.corners.Length; ++j)
        {
            distanceToDestination += Vector3.Distance(path.corners[j - 1], path.corners[j]);
        }
    }
}