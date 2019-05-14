using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddTower1 : MonoBehaviour
{
    private GameObject tower;
    public Button btnTower1;

    public GameObject Tower { get => tower; set => tower = value; }

    // Start is called before the first frame update
    void Start()
    {

        btnTower1.onClick.AddListener(StartWaiting);//Instantiate(GameManager.Instance.TowerPrefab, transform.position, Quaternion.identity);
    }

    public static IEnumerator WaitInput(bool wait, GameObject tower)
    {
        Debug.Log("In Enum");
        while (wait)
        {
            if (Input.anyKeyDown)
            {
                var mousePos = Input.mousePosition;
                var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                Debug.Log(objectPos.x + " " + objectPos.y + " " + objectPos.z);
                GameObject obj = Instantiate(GameManager.Instance.TowerPrefab, objectPos, Quaternion.identity);

                wait = false;
            }
            yield return null;
        }
    }

     void StartWaiting()
    {
        Debug.Log("On BTN click");
        StartCoroutine(WaitInput(true, Tower));
        Debug.Log("After Enum");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
