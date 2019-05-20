using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    
    public float speed = 0.00002f;
    public GameObject target;
    public GameObject[] goals;
    private int goalIndex = 0;
    private float leastDistance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setGoal(GameObject[] goals)
    {
        this.goals = goals;
        target = goals[0];
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        Vector3 targetDir = target.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        Animator an = this.gameObject.GetComponent<Animator>();
        an.SetBool("Running", true);

        if (Vector3.Distance(transform.position, target.transform.position) <= leastDistance)
        {
            if (goalIndex == (goals.Length-1))
            {
                Destroy(this.gameObject);
            }
            else
            {
                goalIndex++;
                target = goals[goalIndex];
            }
        }


    }
}
