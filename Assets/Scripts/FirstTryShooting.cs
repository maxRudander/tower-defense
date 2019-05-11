using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTryShooting : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed = 100f;
    public GameObject target;
    public GameObject cannon;
    public GameObject cannonPipe;
    public float cooldown = 1f;
    private float cooldownleft = 0;
    [Range(1, 500)]
    public int towerRange = 100;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        Skeleton[] enemies = GameObject.FindObjectsOfType<Skeleton>();
        Skeleton nearestSkeleton = null;
        float distance = Mathf.Infinity;

        for (int i = 0; i < enemies.Length; i++) {
            float currentDistance = Vector3.Distance(cannonPipe.transform.position, enemies[i].transform.position);
            if (nearestSkeleton == null || currentDistance < distance) {
                nearestSkeleton = enemies[i];
                distance = currentDistance;

                
                
                
            }

        }
        if (nearestSkeleton == null) {
            //Debug.Log("No skeletons found!");
            return;
        }

        Vector3 direction = nearestSkeleton.transform.position - cannonPipe.transform.position;
        //Quaternion lookRotaiton = Quaternion.LookRotation(direction);
        //cannonPipe.transform.rotation = Quaternion.Euler(0, lookRotaiton.eulerAngles.y, 0);
        cannon.transform.LookAt(nearestSkeleton.transform.position);
        cooldownleft -= Time.deltaTime;
        if (cooldownleft <= 0 && direction.magnitude <= towerRange) {
            cooldownleft = cooldown;
            shot(nearestSkeleton);
        }

    }
    void shot(Skeleton nearestSkeleton) {
        GameObject instBullet = (GameObject)Instantiate(bullet, cannonPipe.transform.position, Quaternion.identity);
        Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidBody.AddForce(-(cannonPipe.transform.position - nearestSkeleton.transform.position).normalized * bulletSpeed); //Bakvänd väg för att testa om de kan bli målsökande
        Debug.Log("skott!");
        Destroy(instBullet, 20f);
    }
}



//        if (Input.GetKeyDown(KeyCode.Space)) {
//            //GameObject instBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
//            cannon.transform.LookAt(target.transform.position);
//            GameObject instBullet = (GameObject)Instantiate(bullet, cannonPipe.transform.position, Quaternion.identity);
//            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();

//            //instBulletRigidBody.AddForce(target.transform.position * bulletSpeed);
//            //instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);
            
//            //instBulletRigidBody.AddForce((target.transform.position - cannonPipe.transform.position).normalized * bulletSpeed);

//            instBulletRigidBody.AddForce(-(cannonPipe.transform.position- target.transform.position  ).normalized * bulletSpeed); //Bakvänd väg för att testa om de kan bli målsökande
//            //instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);


//            Destroy(instBullet, 10.0f);
//        }
//    }
//}