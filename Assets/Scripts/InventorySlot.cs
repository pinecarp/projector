using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private GameObject itemInHand;

    private Collider2D[] inHandColliders;

    private Camera mainCamera;

    private Item item;
    private Controller controller;


    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        
    }

    private void Update()
    {
        
        
        itemInHand = GameObject.FindGameObjectWithTag("InHand");
        
   

    }

    public void OnClick()
    {
        item = GameObject.FindGameObjectWithTag("InHand").GetComponent<Item>();
        
        itemInHand.transform.position = transform.position;
        item.nearPlayer = false;
        controller.isTake = false;
        itemInHand.tag = "Item";
        itemInHand.transform.parent = gameObject.transform;
    }
}
