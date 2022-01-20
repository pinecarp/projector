using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public GameObject inventoryCanvas;
    
    private float itemLerpSpeed = 7;
    private float radius = 1;


    private bool isInInventory = false;
    private bool isPickedUp;

    
    public Transform point;
    
    public GameObject pickupItemCanvas;


    private Collider2D[] itemColliders;
    private GameObject[] onHand;
    
    Camera mainCamera;
    
    public LayerMask PLayerMask;
    
    private Vector3 mousePos;
    public Transform backpackpoint;

    Controller controller;
    

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

    private void Update()
    {

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        itemColliders =  Physics2D.OverlapCircleAll(transform.position, radius, PLayerMask);

        PickUp();

        if (isPickedUp)
        {
            transform.position = Vector3.Lerp(transform.position, backpackpoint.transform.position, 3 * Time.deltaTime);
        }
        


    }
    
     
    private void PickUp()
    {
        if (itemColliders.Length >= 1 & inventoryCanvas.activeSelf == false)
        {
            foreach (var item in itemColliders)
            {
                if (item.tag == "Player")
                {
                    pickupItemCanvas.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        inventoryCanvas.SetActive(true);
                        transform.parent = inventoryCanvas.transform;
                        isPickedUp = true;
                    }
                }

            }
        }
        else
        {
            pickupItemCanvas.SetActive(false);
        }
        
    }

}
