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
<<<<<<< HEAD
            instBulletRigidBody.AddForce((target.transform.position - this.transform.position).normalized * bulletSpeed);
            //instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);
=======
            instBulletRigidBody.AddForce(target.transform.position * bulletSpeed);
     //       instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);
>>>>>>> a158a4ea43037b6d03ea1d99ad2c53f1a8d03cba

            Destroy(instBullet, 3.0f);

<<<<<<< HEAD







=======
        
>>>>>>> a158a4ea43037b6d03ea1d99ad2c53f1a8d03cba


        }
    }
<<<<<<< HEAD
    }
=======
}
>>>>>>> a158a4ea43037b6d03ea1d99ad2c53f1a8d03cba

