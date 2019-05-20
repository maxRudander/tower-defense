using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddTower1 : MonoBehaviour
{


    public GameObject canonTower;
    public GameObject gameManager;

    public float offset = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        canonTower = GameObject.FindWithTag("CanonTower");
    }

    public static IEnumerator WaitInput(bool wait, GameObject towerToAdd, float offset, int price)
    {
        Debug.Log("In Enum");
        while (wait)
        {
            if (Input.anyKeyDown)
            {
                RaycastHit hit;

                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)){
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
        Debug.Log("On BTN click");
        StartCoroutine(WaitInput(true, canonTower, offset, 0));
        Debug.Log("After Enum");
    }

    public void addCanonTower(){
        canonTower = GameObject.FindWithTag("CanonTower");
        StartCoroutine(WaitInput(true, canonTower, offset, 10));
    }

    public void addFireTower(){
        canonTower = GameObject.FindWithTag("CanonTower");
        StartCoroutine(WaitInput(true, canonTower, offset, 20));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
