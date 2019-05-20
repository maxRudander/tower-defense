﻿using UnityEngine;
using System.Collections;

public class bulletTower : MonoBehaviour
{

    public float Speed;
    public Transform target;
    public Transform LookAtBul;
    public Tower twr;

    public int dmg;

    public float aoe;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        
        if (target)
        {
            LookAtBul.transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == target)
        {
            
            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                GameObject enemy = enemies[i];
                float dist = Vector3.Distance(other.transform.position, transform.position);
                Debug.Log(dist);
                
                if (dist<=aoe)
                {
                    Debug.Log("AOE");
                    Destroy(enemy.gameObject);
                }
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}