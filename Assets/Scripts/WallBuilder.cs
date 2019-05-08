using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour {
    public Transform pointPreFabTree; //första trädet
    [Range(1, 100)]
    public int numberOfTrees = 10;
    [Range(1, 100)]
    public int distanceBetweenTrees = 30;
    [Range(1, 10)]
    public int numberOfRows = 1;

    private Transform[] points;
    public bool Horizontal = true;
    public bool Vertical = false;



    // Start is called before the first frame update
    void Start() {

    }
    void Initilize() {

    }
    private void Awake() {
        points = new Transform[numberOfTrees];
        BuildWall();
    }

    // Update is called once per frame
    void Update() {

    }
    void BuildWall() {
        int xincrease = 0;
        int zincrease = 0;
        if (Horizontal && !Vertical) {
            xincrease = distanceBetweenTrees;
        } else if (Vertical && !Horizontal) {
            zincrease = distanceBetweenTrees;
        }

        int x = distanceBetweenTrees / 2;
        int z = distanceBetweenTrees / 2;
        for (int row = 0; row < numberOfRows; row++) {
            for (int j = 0; j < points.Length; j++) {
                Transform point = Instantiate(pointPreFabTree);
                point.SetParent(transform, false);
                Vector3 p = new Vector3(x, 0, z);
                point.localPosition += p;
                point.localRotation = Quaternion.Euler(-90f, (float)-Random.Range(0, 360), 0f);
                points[j] = point;
                x = x + xincrease;
                z = z + zincrease;

            }
            if (Horizontal) {
                z = z - distanceBetweenTrees;
                x = distanceBetweenTrees / 2;
            }
            else {
                z = distanceBetweenTrees / 2;
                x = x + distanceBetweenTrees;
            }
        }
    }
}
