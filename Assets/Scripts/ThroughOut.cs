using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ThroughOut : MonoBehaviour
{
    private float randDirection;
    private float transformTime;

    private bool isThrough;
    

    
    public GameObject itemPrefab;
    private GameObject newPrefab;
    private GameObject player;

    private Variables variables;
    
    private Random random = new Random();

    private Vector3 prefabPosition;

    void Awake()
    {
        variables = GameObject.FindGameObjectWithTag("GameController").GetComponent<Variables>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Through();
        if (isThrough)
        {
            newPrefab.transform.position = player.transform.position;
            isThrough = false;
        }
    }

    private void Through()
    {
        if (Input.GetKeyDown(KeyCode.Q) & variables.inHand)
        {
            randDirection = (float)(random.NextDouble() * 0.1f + 0.1f);

            variables.inHand = false;
            isThrough = true;

            Destroy(GameObject.FindGameObjectWithTag("InHand"));
            newPrefab = Instantiate(itemPrefab, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
        }
    }
}
