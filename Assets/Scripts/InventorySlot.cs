using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool isFull;
    public bool clickOnItem;
    
    private GameObject itemInHand;
    private GameObject[] itemsInInventory;

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
        if (isFull == false)
        {
            item = GameObject.FindGameObjectWithTag("InHand").GetComponent<Item>();
            item.itemCanMove = false;
            variables.inHand = false;
            isFull = true;
            clickOnItem = false;
            
            itemInHand.transform.position = transform.position;
            itemInHand.transform.parent = gameObject.transform;
            
            itemInHand.tag = "InInventory";
        }
        else
        {
            itemsInInventory = GameObject.FindGameObjectsWithTag("InInventory");
  
            foreach (var i in itemsInInventory)
            {
                if (i.transform.position == transform.position & !variables.inHand)
                {
                    i.gameObject.tag = "InHand";
                    gameObject.transform.DetachChildren();
                    i.GetComponent<Item>().itemCanMove = true;
                    variables.inHand = true;
                    clickOnItem = true;
                    isFull = false;
                }
            }

        }
    }
}
