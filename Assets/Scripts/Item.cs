using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    private float itemLerpSpeed = 7;
    private float radius = 1;
    
    public bool itemCanMove = false;
    
    public Transform point;
    
    public GameObject pickupItemCanvas;
    
    private Collider2D[] itemColliders;
    private GameObject[] onHand;
    
    private Camera mainCamera;
    
    public LayerMask PLayerMask;
    
    private Vector3 mousePos;

    private Variables variables;


    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        variables = GameObject.FindGameObjectWithTag("GameController").GetComponent<Variables>();
    }

    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        itemColliders =  Physics2D.OverlapCircleAll(point.transform.position, radius, PLayerMask);

        PickUp();
    }
    
     
    private void PickUp()
    {
        if (itemColliders.Length >= 1 & variables.inHand == false)
        {
            foreach (var item in itemColliders)
            {
                if (item.tag == "Player")
                {
                    pickupItemCanvas.SetActive(true);
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        itemCanMove = true;
                        variables.inHand = true;
                        
                        gameObject.tag = "InHand";
                        gameObject.layer = 7;
                    }
                }
            }
        }
        else
        {
            pickupItemCanvas.SetActive(false);
        }
        
        if (itemCanMove & gameObject.tag == "InHand")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(mousePos.x,mousePos.y,15), itemLerpSpeed * Time.deltaTime);
        }
    }

}
