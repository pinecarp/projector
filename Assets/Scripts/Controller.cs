using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
   
    private float playerSpeed = 5;

    public Camera mainCamera;
    
     private void Update()
     {
         Movement();
     }

     private void Movement()
     {
          float horizontalinput = Input.GetAxis("Horizontal");
          float verticalinput = Input.GetAxis("Vertical");

          var position = transform.position;
          position += Vector3.right * horizontalinput * playerSpeed * Time.deltaTime;
          position += Vector3.up * verticalinput * playerSpeed * Time.deltaTime;
          transform.position = position;
     }

     private void OnTriggerStay2D(Collider2D collider)
     {
         if (collider.gameObject.CompareTag("Friend"))
         {
             Rigidbody2D rb = GetComponent<Rigidbody2D>();

             rb.isKinematic = false;
             Vector2 difference = transform.position - collider.transform.position;
             difference = difference.normalized / 2;
             rb.AddForce(difference, ForceMode2D.Impulse);
             StartCoroutine(knock(rb));
             
         }
     }

     private IEnumerator knock(Rigidbody2D rb)
     {
         yield return new WaitForSeconds(0.5f);
         rb.velocity = Vector2.zero;
         rb.isKinematic = true;
     }
}
