using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTryShooting : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public GameObject target;
    public Material weaponTracerMaterial;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject instBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();


            Vector3 direction = (target.transform.position - bullet.transform.position).normalized;

            instBulletRigidBody.AddForce(direction * bulletSpeed);
            //instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);

            Destroy(instBullet, 3.0f);

        }
        if (Input.GetKeyDown(KeyCode.End)) {
           
           
        }
    }
}
