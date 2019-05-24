using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class checkPath : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    NavMeshAgent previousAgent;
    private NavMeshPath path;
    bool showPath = false;

    private float elapsed = 0.0f;
    void Start()
    {
        path = new NavMeshPath();
        elapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            int layerMask = 1 << 12;
            //layerMask = ~layerMask;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                agent = hit.transform.gameObject.GetComponent<NavMeshAgent>();
                if (previousAgent != null)
                {
                    previousAgent.GetComponent<LineRenderer>().enabled = false;
                    previousAgent = null;
                }
            }
            else
            {
                previousAgent = agent;
                agent = null;
            }
        }

        if (agent != null)
        {
            showPath = true;
            elapsed += Time.deltaTime;
            if (elapsed > 1.0f)
            {
                Debug.Log("elapsed" + elapsed);
                elapsed -= 1.0f;

                NavMesh.CalculatePath(agent.transform.position, agent.destination, NavMesh.AllAreas, path);
                Debug.Log(path.corners.Length);
            }

            agent.GetComponent<LineRenderer>().positionCount = agent.path.corners.Length;
            int i = 0;
            foreach (Vector3 v in agent.path.corners)
            {
                agent.GetComponent<LineRenderer>().SetPosition(i, v);
                //Debug.Log("position agent"+g.transform.position);
                //Debug.Log("position corner = "+v);
                i++;

            }
            if (agent.GetComponent<LineRenderer>().enabled == false)
                agent.GetComponent<LineRenderer>().enabled = true;

        }

        if (previousAgent != null)
        {
            previousAgent.GetComponent<LineRenderer>().enabled = false;
            previousAgent = null;
        }


    }
}
