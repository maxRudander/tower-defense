using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tower : MonoBehaviour
{

    public Transform shootElement;
    public Transform LookAtObj;

    public GameObject bullet;
    public Transform target;

    public GameManager gm;

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

    public int towerLevel;

    public int price;

    bool isShoot;
    void Start()
    {
        towerLevel = 1;
        updateRange();
        gm = GameObject.FindObjectsOfType<GameManager>()[0];
    }

    public void updateRange()
    {
        gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<SphereCollider>().radius = range;
    }

    public void upgradeTower()
    {   
        Debug.Log("TESTar");
        Debug.Log(gm.Money );
        Debug.Log(towerLevel * price);
        if (gm.Money >= (towerLevel+1) * price)
        {
            Debug.Log("TEST2");
            towerLevel++;
            gm.ModifyMoney(-towerLevel * price);
            dmg = (int)(dmg * 1.2);
            range *= 1.05f;
            attackSpeed *= 1.25f;
            aoeSize *= 1.05f;
            aoeDmg = dmg/2;
            if (slowAmout < 1)
            {
                slowAmout *= 0.9f;
                slowDuration *= 1.1f;
            }
            gameObject.transform.localScale += new Vector3(0.0f, 0.1f, 0.0f);
            transform.GetChild(1).transform.GetChild(0).transform.gameObject.transform.GetChild(4).transform.gameObject.GetComponent<Text>().text = gameObject.GetComponent<Tower>().towerLevel.ToString();
            updateRange();
        }
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
        if (target != null)
        {
            b.GetComponent<bulletTower>().twr = this;
            b.GetComponent<bulletTower>().target = target;
            b.GetComponent<bulletTower>().dmg = dmg;
            b.GetComponent<bulletTower>().aoeSize = aoeSize;
            b.GetComponent<bulletTower>().aoeDmg = aoeDmg;
            b.GetComponent<bulletTower>().slowAmout = slowAmout;
            b.GetComponent<bulletTower>().slowDuration = slowDuration;
            Destroy(b, 10f);
        }
        else
        {
            Destroy(b);
        }



        this.shotsFired++;

        Debug.Log(gameObject + "\nshotsFired: " + shotsFired + "Kills: " + kills + "Total Dmg" + totalDmgDone);

        isShoot = false;
    }
}
