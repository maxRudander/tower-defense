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
            GameObject instBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
<<<<<<< HEAD
            instBulletRigidBody.AddForce(target.transform.position * bulletSpeed);
            instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);
=======
            instBulletRigidBody.AddForce((target.transform.position - this.transform.position).normalized * bulletSpeed);
            //instBulletRigidBody.AddForce(Vector3.forward * bulletSpeed);
>>>>>>> parent of 81bb72e... 6fgddgdg

            //Destroy(instBullet, 3.0f);




            //    Vector3 dir = target.transform.position - instBulletRigidBody.transform.localPosition;

            //float distThisFrame = bulletSpeed * Time.deltaTime;

            //if (dir.magnitude <= distThisFrame) {
            //    // We reached the node
            //    Debug.Log("HIT!");
            //} else {
            //    // TODO: Consider ways to smooth this motion.

            //    //Move towards node
            //    target.transform.Translate(dir.normalized * distThisFrame, Space.World);
            //    Quaternion targetRotation = Quaternion.LookRotation(dir);
            //    instBulletRigidBody.transform.rotation = Quaternion.Lerp(instBulletRigidBody.transform.rotation, targetRotation, Time.deltaTime * 5);






        }
    }
    }
<<<<<<< HEAD
}
=======

>>>>>>> parent of 81bb72e... 6fgddgdg
