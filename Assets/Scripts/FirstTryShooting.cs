using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTryShooting : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed = 100f;
    public GameObject target;
    public GameObject cannon;
    public GameObject cannonPipe;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //GameObject instBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            cannon.transform.LookAt(target.transform.position);
            GameObject instBullet = (GameObject)Instantiate(bullet, cannonPipe.transform.position, Quaternion.identity);
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();

            //instBulletRigidBody.AddForce(target.transform.position * bulletSpeed);
            //instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);
            
            //instBulletRigidBody.AddForce((target.transform.position - cannonPipe.transform.position).normalized * bulletSpeed);

            instBulletRigidBody.AddForce(-(cannonPipe.transform.position- target.transform.position  ).normalized * bulletSpeed); //Bakvänd väg för att testa om de kan bli målsökande
            //instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);


            Destroy(instBullet, 10.0f);
        }
    }
}