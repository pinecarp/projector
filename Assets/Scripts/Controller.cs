using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    private float playerSpeed = 3;
    private float itemLerpSpeed = 7;
    private float radius = 1;

    public bool isTake;
    private bool isInInventory;
    
    //public Transform point;
    
    //public GameObject item;
    //public GameObject pickupItemCanvas;
    //public GameObject inventoryCanvas;
    
    private Collider2D[] itemColliders;
    
    public Camera mainCamera;
    
    //public LayerMask itemsLayer;
    //private Vector3 mousePos;
    
    
     private void Update()
     {
         //mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
         //itemColliders =  Physics2D.OverlapCircleAll(point.transform.position, radius, itemsLayer);
         
         Movement();
         BackpackPickUp();
         

     }

     private void Movement()
     {
         float horizontalinput = Input.GetAxis("Horizontal");
          float verticalinput = Input.GetAxis("Vertical");
         
          transform.position += Vector3.right * horizontalinput * playerSpeed * Time.deltaTime;
          transform.position += Vector3.up * verticalinput * playerSpeed * Time.deltaTime;
     }
     

     private void BackpackPickUp()
     {/*
         if (itemColliders.Length >= 1)
         {
             foreach (var item in itemColliders)
             {
                 if (item.tag == "backpack")
                 {
                     inventoryCanvas.SetActive(true);
                 }
             }
         }
         */
     }

}
