using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera startCam;
    public Camera midCam;
    public Camera endCam;
    private int nextCam;

    // Start is called before the first frame update
    void Start()
    {

        startCam.enabled = true;
        midCam.enabled = false;
        endCam.enabled = false;
        nextCam = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(nextCam == 1)
            {
                midCam.enabled = true;
                startCam.enabled = false;
                endCam.enabled = false;
            }else if(nextCam == 2)
            {
                midCam.enabled = false ;
                startCam.enabled = false;
                endCam.enabled = true;
            }else if(nextCam == 0)
            {
                midCam.enabled = false;
                startCam.enabled = true;
                endCam.enabled = false;
            }
            nextCam++;
            nextCam = nextCam % 3;
        }
    }

}
