using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddTower1 : MonoBehaviour
{


    public GameObject canonTower;

    public GameObject fireTower;

    public GameObject iceTower;
    public GameObject gameManager;



    // Start is called before the first frame update
    void Start()
    {

    }

    public static IEnumerator WaitInput(bool wait, GameObject towerToAdd, int price, Color color)
    {
        Debug.Log("In Enum");
        while (wait)
        {

            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("In RIGHTBTN");
                yield return null;
            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                int layerMask = 1 << 10;
                layerMask = ~layerMask;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
                {
                    Debug.Log(hit.point + " ");
                    towerToAdd.transform.position = hit.point;
                    GameObject tower = Instantiate(towerToAdd, towerToAdd.transform.position, Quaternion.identity);
                    tower.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", color);
                    tower.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_Color", color);
                    tower.transform.GetChild(0).transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_Color", color);
                    tower.transform.GetChild(0).transform.GetChild(4).GetComponent<Renderer>().material.SetColor("_Color", color);
                    GameManager gm = GameObject.FindObjectsOfType<GameManager>()[0];
                    gm.ModifyMoney(-price);
                    Text money = GameObject.Find("txtMoney").GetComponent<Text>();
                    //money.text = gm.money.ToString();
                }
                wait = false;
            }
            yield return null;
        }
    }

    public void StartWaiting()
    {

    }

    public void addCanonTower()
    {
            StartCoroutine(WaitInput(true, canonTower, 10, Color.green));
    }

    public void addFireTower()
    {
        StartCoroutine(WaitInput(true, fireTower, 20, Color.red));
    }

    public void addIceTower()
    {
        StartCoroutine(WaitInput(true, iceTower, 50, Color.blue));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
