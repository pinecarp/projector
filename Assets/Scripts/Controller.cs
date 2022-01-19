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

    private bool isTake;
    
    public Transform point;
    
    public GameObject pickupCanvas;
    public GameObject item;
    
    public Camera mainCamera;
    
    public LayerMask itemsLayer;
    
    private Vector3 mousePos;

     
     private void Update()
     {
         mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
         
         Movement();
         Items();

     }

     private void Movement()
     {
         float horizontalinput = Input.GetAxis("Horizontal");
          float verticalinput = Input.GetAxis("Vertical");
         
          transform.position += Vector3.right * horizontalinput * playerSpeed * Time.deltaTime;
          transform.position += Vector3.up * verticalinput * playerSpeed * Time.deltaTime;
     }
     private void Items()
     {
         Collider2D[] itemColliders =  Physics2D.OverlapCircleAll(point.transform.position, radius, itemsLayer);

         if (itemColliders.Length >= 1 & isTake == false)
         {
             pickupCanvas.SetActive(true);
         }
         else
         {
             pickupCanvas.SetActive(false);
         }

         if (Input.GetKeyDown(KeyCode.E) & itemColliders.Length >= 1)
         {
             isTake = true;
         }

         if (isTake == true)
         {
             item.transform.position = Vector3.Lerp(item.transform.position, new Vector3(mousePos.x,mousePos.y,5), itemLerpSpeed * Time.deltaTime);
         }
     }

}
