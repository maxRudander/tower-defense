using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTryShooting : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed = 100f;
    public GameObject target;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject instBullet = (GameObject)Instantiate(bullet, this.transform.position, Quaternion.identity);
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidBody.AddForce((target.transform.position - this.transform.position).normalized * bulletSpeed);
            //instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);

            Destroy(instBullet, 3.0f);










        }
    }
    }

