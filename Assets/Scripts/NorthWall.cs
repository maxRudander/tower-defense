using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthWall : MonoBehaviour {
    public Transform pointPreFabTree; //första trädet
    private Transform[] points;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("start");
        points = new Transform[10];
        BuildNorthWall();
    }
    void Initilize() {

    }

    // Update is called once per frame
    void Update() {

    }
    void BuildNorthWall() {
        Debug.Log("BuildNorthWall");
        int x = 0;
        for (int i = 0; i < points.Length; i++) {
            Transform point = Instantiate(pointPreFabTree);
            //   point.localScale = scale;
            point.SetParent(transform,false);
           // Vector3 p = new Vector3(x-10, 0, 0+10);
           // point.localPosition += p;
            points[i] = point;
            x = x + 30;
        }
    }
}
