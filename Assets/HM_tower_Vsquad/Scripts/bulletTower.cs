using UnityEngine;
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
                            enemy.GetComponent<NavMeshAgent>().speed = 1;
                            enemy.GetComponent<Skeleton>().currentMovementSpeed = enemy.GetComponent<NavMeshAgent>().speed;
                            enemy.GetComponent<Skeleton>().slowDuration = slowDuration/1000;
                        }
                        twr.totalDmgDone += aoeDmg;
                    }
                }
            }
            if (!other.GetComponent<Skeleton>().isSlowed)
            {
                other.GetComponent<NavMeshAgent>().speed *=slowAmout;
                other.GetComponent<Skeleton>().currentMovementSpeed = other.GetComponent<NavMeshAgent>().speed;
                other.GetComponent<Skeleton>().slowDuration = slowDuration/1000;
            }
            other.GetComponent<Skeleton>().hpCurrent -= dmg;
            other.GetComponent<Skeleton>().lastBulletHit = gameObject;
            twr.totalDmgDone += dmg;
        }
    }

    public void updateTowerKills()
    {
        twr.kills++;
        Destroy(gameObject);
    }

}
