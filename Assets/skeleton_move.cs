using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton_move : MonoBehaviour
{

    public float speed = 5000000.0f;
    public GameObject tar;
    public Animation aniWalk;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().Play("Walk02");
    }

    // Update is called once per frame
    void Update()
    {
        // turn
        Vector3 lookAt = tar.transform.position; //p till t = t-p.normalized
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);

        //
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, tar.transform.position, step);


    }

    void turn()
    {

    }
}
