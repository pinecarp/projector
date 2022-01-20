using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    private float itemLerpSpeed = 7;
    private float radius = 1;


    private bool isInInventory = false;
    public bool nearPlayer = false;
    
    public Transform point;
    
    public GameObject pickupItemCanvas;


    private Collider2D[] itemColliders;
    private GameObject[] onHand;
    
    Camera mainCamera;
    
    public LayerMask PLayerMask;
    
    private Vector3 mousePos;

    Controller controller;
    

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

    private void Update()
    {

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        itemColliders =  Physics2D.OverlapCircleAll(point.transform.position, radius, PLayerMask);

        PickUp();
        putInInventory();
    }
    
     
    private void PickUp()
    {
        if (itemColliders.Length >= 1 & controller.isTake == false)
        {
            foreach (var item in itemColliders)
            {
                if (item.tag == "Player")
                {
                    
                    pickupItemCanvas.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        nearPlayer = true;
                        controller.isTake = true;
                        
                        gameObject.tag = "InHand";
                        gameObject.layer = 7;
                    }
                }
                else
                {
                    nearPlayer = false;
                }
            }
        }
        else
        {
            pickupItemCanvas.SetActive(false);
        }
        
        if (nearPlayer == true & gameObject.tag == "InHand")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(mousePos.x,mousePos.y,15), itemLerpSpeed * Time.deltaTime);
        }
    }

    void putInInventory()
    {
        if (Input.GetMouseButtonDown(1) & nearPlayer == true)
        {
            nearPlayer = false;
        }
    }
}
