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

    public int kills;

    public int shotsFired;

    public int totalDmgDone;
    bool isShoot;
    void Start()
    {
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
        yield return new WaitForSeconds(100 / attackSpeed);
        GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
        b.GetComponent<bulletTower>().twr = this;
        b.GetComponent<bulletTower>().target = target;
        b.GetComponent<bulletTower>().dmg = dmg;
        b.GetComponent<bulletTower>().aoeSize = aoeSize;
        b.GetComponent<bulletTower>().aoeDmg = aoeDmg;
        this.shotsFired++;

        Debug.Log(gameObject + "\nshotsFired: " + shotsFired + "Kills: " + kills + "Total Dmg" + totalDmgDone);

        isShoot = false;
    }
}
