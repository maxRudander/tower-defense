using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{

    public Transform shootElement;
    public Transform LookAtObj;

    public GameObject bullet;
    public Transform target;

    public int dmg = 10;
    public float attackSpeed = 1;

    public float range = 30;

    public int aoeDmg;

    public float aoeSize;

    public float slowAmout = 1;
    public float slowDuration = 1000;

    public int kills;

    public int shotsFired;

    public int totalDmgDone;

    private int towerLevel;

    bool isShoot;
    void Start()
    {
        towerLevel = 1;
        updateRange();
    }

    public void updateRange()
    {
        gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<SphereCollider>().radius = range;
    }

    void Update()
    {
        if (target)
        {
            LookAtObj.transform.LookAt(target);
            if (attackSpeed > 0)
            {
                if (!isShoot)
                {
                    StartCoroutine(shoot());
                }
            }
        }
    }

    IEnumerator shoot()
    {
        isShoot = true;
        yield return new WaitForSeconds(1000 / attackSpeed);
        GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
        b.GetComponent<bulletTower>().twr = this;
        b.GetComponent<bulletTower>().target = target;
        b.GetComponent<bulletTower>().dmg = dmg;
        b.GetComponent<bulletTower>().aoeSize = aoeSize;
        b.GetComponent<bulletTower>().aoeDmg = aoeDmg;
        b.GetComponent<bulletTower>().slowAmout = slowAmout;
        b.GetComponent<bulletTower>().slowDuration = slowDuration;
        Destroy(b, 10f);


        this.shotsFired++;

        Debug.Log(gameObject + "\nshotsFired: " + shotsFired + "Kills: " + kills + "Total Dmg" + totalDmgDone);

        isShoot = false;
    }
}
