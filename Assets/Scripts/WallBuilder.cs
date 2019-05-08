using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour {
    public Transform pointPreFabTree; //första trädet
    [Range(1, 100)]
    public int numberOfTrees = 10;
    public string wall = "n";
    private Transform[] points;


    // Start is called before the first frame update
    void Start() {

    }
    void Initilize() {

    }
    private void Awake() {
        Debug.Log("start");

        points = new Transform[numberOfTrees];
        BuildWall();
    }

    // Update is called once per frame
    void Update() {

    }
    void BuildWall() {
        int xincrease = 0;
        int zincrease = 0;
        Debug.Log("BuildWall");
        if (wall.Equals("n")) { //NORTH
            xincrease = 30;
        } else if (wall.Equals("s")) {// SOUTH
            xincrease = 30;
        } else if (wall.Equals("w")) {//WEST
            zincrease = 30;
        } else if (wall.Equals("e")) { //EAST
            zincrease = 30;
        }

        int x = 15;
        int z = 15;
        for (int i = 0; i < points.Length; i++) {
            Transform point = Instantiate(pointPreFabTree);
            point.SetParent(transform, false);
            Vector3 p = new Vector3(x , 0, z );
            point.localPosition += p;
            point.localRotation = Quaternion.Euler(-90f, (float)-Random.Range(0, 360), 0f);
            points[i] = point;
            x = x + xincrease;
            z = z + zincrease;

        }
    }
}
