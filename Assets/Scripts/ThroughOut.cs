using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = System.Random;

public class ThroughOut : MonoBehaviour
{
    private float randDirection;
    private float transformTime;

    private bool isThrough;

    private string name;
    
    private GameObject itemObject;
    private GameObject newItem;
    private GameObject player;

    private Variables variables;
    private Item item;
    
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
            newItem.transform.position = player.transform.position;
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

            itemObject = GameObject.FindGameObjectWithTag("InHand");
            item = itemObject.GetComponent<Item>();

            name = itemObject.gameObject.name;
            
            Destroy(itemObject);

            item.itemCanMove = false;
            itemObject.gameObject.tag = "Item";
            item.enabled = true;
            itemObject.GetComponent<Collider2D>().enabled = true;
            
            newItem = Instantiate(itemObject, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
            newItem.gameObject.name = name;
        }
    }
}
