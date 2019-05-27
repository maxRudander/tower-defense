﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class bulletTower : MonoBehaviour
{

    public float Speed;
    public Transform target;
    public Transform LookAtBul;
    public Tower twr;

    public int dmg;

    public float aoeSize;

    public int aoeDmg;

    public float slowAmout;

    public float slowDuration;

public GameObject explosion;


    void Update()
    {
        if (target)
        {
            LookAtBul.transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == target)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                GameObject enemy = enemies[i];
                if (!enemy.gameObject.transform.Equals(target))
                {
                    float dist = Vector3.Distance(other.transform.position, enemy.transform.position);
                    if (dist <= aoeSize)
                    {
                        enemy.GetComponent<Skeleton>().lastBulletHit = gameObject;
                        enemy.GetComponent<Skeleton>().hpCurrent -= aoeDmg;
                        if (!enemy.GetComponent<Skeleton>().isSlowed)
                        {
                            enemy.GetComponent<NavMeshAgent>().speed *= slowAmout;
                            enemy.GetComponent<Skeleton>().currentMovementSpeed = enemy.GetComponent<NavMeshAgent>().speed;
                            enemy.GetComponent<Skeleton>().slowDuration = slowDuration / 1000;
                        }
                        twr.totalDmgDone += aoeDmg;
                    }
                }
            }
            if (!other.GetComponent<Skeleton>().isSlowed)
            {
                other.GetComponent<NavMeshAgent>().speed *= slowAmout;
                other.GetComponent<Skeleton>().currentMovementSpeed = other.GetComponent<NavMeshAgent>().speed;
                other.GetComponent<Skeleton>().slowDuration = slowDuration / 1000;
            }
            other.GetComponent<Skeleton>().hpCurrent -= dmg;
            other.GetComponent<Skeleton>().lastBulletHit = gameObject;

            if (explosion != null)
            {
                GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
                float sqrAoeSize = aoeSize / 5;
                for (int nbr = 0; nbr < exp.transform.childCount; nbr++)
                {
                    exp.transform.GetChild(nbr).localScale += new Vector3(sqrAoeSize, sqrAoeSize, sqrAoeSize);
                    Destroy(exp.transform.GetChild(nbr).gameObject, 2.0f);
                }               
                Destroy(exp, 2.0f);
            }
            twr.totalDmgDone += dmg;
        }
    }

    public void updateTowerKills()
    {
        GameManager gm = GameObject.FindObjectsOfType<GameManager>()[0];
		gm.ReportKill();
		twr.kills++;
        Destroy(gameObject);
    }

}
