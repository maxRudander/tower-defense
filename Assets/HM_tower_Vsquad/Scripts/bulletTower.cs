using UnityEngine;
using System.Collections;

public class bulletTower : MonoBehaviour
{

    public float Speed;
    public Transform target;
    public Transform LookAtBul;
    public Tower twr;

    public int dmg;

    public float aoeSize;

    public int aoeDmg;
    // Use this for initialization

    // Update is called once per frame
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
                        twr.totalDmgDone += aoeDmg;
                    }
                }
            }
            other.GetComponent<Skeleton>().hpCurrent -= dmg;
            other.GetComponent<Skeleton>().lastBulletHit = gameObject;
            twr.totalDmgDone += dmg;
        }
    }

    public void updateTowerKills(){
        twr.kills++;
        Destroy(gameObject);
    }

}
