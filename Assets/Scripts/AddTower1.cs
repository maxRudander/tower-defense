using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddTower1 : MonoBehaviour
{


    public GameObject canonTower;

    public GameObject arrowTower;

    public GameObject canonTower2;
    public GameObject gameManager;

    public float offset = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public static IEnumerator WaitInput(bool wait, GameObject towerToAdd, float offset, int price)
    {
        Debug.Log("In Enum");
        while (wait)
        {
            if (Input.anyKeyDown)
            {
                RaycastHit hit;
                int layerMask = 1 << 9;
                layerMask = ~layerMask;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
                {
                    Debug.Log(hit.point +" " + hit.normal * offset);
                    towerToAdd.transform.position = hit.point + hit.normal * offset;
                    Instantiate(towerToAdd, towerToAdd.transform.position, Quaternion.identity);
                    GameManager gm = GameObject.FindObjectsOfType<GameManager>()[0];
                    gm.money -= price;
                    Text money = GameObject.Find("txtMoney").GetComponent<Text>();
                    money.text = gm.money.ToString();
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
        StartCoroutine(WaitInput(true, canonTower, offset, 10));
    }

    public void addArrowTower()
    {
        StartCoroutine(WaitInput(true, arrowTower, offset, 20));
    }

    public void addCanonTower2()
    {
        StartCoroutine(WaitInput(true, canonTower2, offset, 20));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
