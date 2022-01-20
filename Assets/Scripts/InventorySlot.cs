using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private GameObject itemInHand;

    private Collider2D[] inHandColliders;

    private Item item;

    private Variables variables;

    
    private void Awake()
    {
        variables = GameObject.FindGameObjectWithTag("GameController").GetComponent<Variables>();
    }

    private void Update()
    {
        itemInHand = GameObject.FindGameObjectWithTag("InHand");
    }

    public void OnClick()
    {
        item = GameObject.FindGameObjectWithTag("InHand").GetComponent<Item>();

        item.itemCanMove = false;
        variables.inHand = false;
        
        itemInHand.tag = "Item";
        
        itemInHand.transform.position = transform.position;
        itemInHand.transform.parent = gameObject.transform;
    }
}
