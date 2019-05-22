using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class TowerTrigger : MonoBehaviour
{

    public Tower twr;
    public bool lockE;
    public GameObject curTarget;
    private NavMeshPath path;

    void start(){
        path = new NavMeshPath();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !lockE)
        {
            twr.target = other.gameObject.transform;
            curTarget = other.gameObject;
            lockE = true;
        }
    }


    void Update()
    {

        if (!curTarget)
        {
            lockE = false;
            float closestDist = Mathf.Infinity;
            int closestIndex = -1;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = enemies.Length - 1; i >= 0; i--)
            {
                float distance = 0.0f;
                GameObject enemy = enemies[i];
                // Debug.Log(enemy.GetComponent<Skeleton>().GetComponent<NavMeshAgent>().destination);
                // Debug.Log(enemy.GetComponent<Skeleton>().transform.position);
                // Debug.Log(NavMesh.AllAreas);
                // NavMesh.CalculatePath(enemy.GetComponent<Skeleton>().transform.position, enemy.GetComponent<Skeleton>().GetComponent<NavMeshAgent>().destination, NavMesh.AllAreas, path);

                // for(int j = 1; j < path.corners.Length; ++j){
                //     distance += Vector3.Distance( path.corners[i-j], path.corners[j] );
                // }
                // Debug.Log(distance);
                // if(distance < closestDist){
                //     closestDist = distance;
                //     closestIndex = i;
                // }
                Vector3 diff = enemy.transform.position - this.transform.position;
                float curDistance = diff.sqrMagnitude;

				float dist = Vector3.Distance(enemy.transform.position, transform.position);
                float radius = twr.transform.GetChild(0).transform.GetChild(3).GetComponent<SphereCollider>().radius;

                if (dist*dist < closestDist && dist*dist < 25*radius * radius)
                {
                    Debug.Log("Found new target within range!");
                    closestDist = dist*dist;
                    closestIndex = i;
                }
            }
            if (closestIndex != -1)
            {

                twr.target = enemies[closestIndex].gameObject.transform;
                curTarget = enemies[closestIndex].gameObject;
                lockE = true;
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && other.gameObject == curTarget)
        {
            lockE = false;
        }
    }

}
