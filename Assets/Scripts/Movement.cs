using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
     [SerializeField] private float speed = 5;


     
     private void Update()
     {
         float horizontalinput = Input.GetAxis("Horizontal");
         float verticalinput = Input.GetAxis("Vertical");
         
         transform.position += Vector3.right * horizontalinput * speed * Time.deltaTime;
         transform.position += Vector3.up * verticalinput * speed * Time.deltaTime;
         

     }
     
}
