using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    private float playerSpeed = 3;

    public bool isTake;

    public Camera mainCamera;
    

    
     private void Update()
     {

         Movement();

     }

     private void Movement()
     {
         float horizontalinput = Input.GetAxis("Horizontal");
          float verticalinput = Input.GetAxis("Vertical");
         
          transform.position += Vector3.right * horizontalinput * playerSpeed * Time.deltaTime;
          transform.position += Vector3.up * verticalinput * playerSpeed * Time.deltaTime;
     }
     

}
