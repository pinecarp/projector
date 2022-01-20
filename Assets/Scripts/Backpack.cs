using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public GameObject inventoryCanvas;
    
    private float lerpSpeed = 3;
    private float radius = 1;

    private bool isPickedUp;
    
    public GameObject pickupItemCanvas;
    
    private Collider2D[] itemColliders;
    private GameObject[] onHand;

    public LayerMask PLayerMask;

    public Transform backpackpoint;

    
    private void Update()
    {
        itemColliders =  Physics2D.OverlapCircleAll(transform.position, radius, PLayerMask);

        if (isPickedUp)
        {
            transform.position = Vector3.Lerp(transform.position, backpackpoint.transform.position, lerpSpeed * Time.deltaTime);
        }
        
        PickUpBackpack();
    }
    
     
    private void PickUpBackpack()
    {
        if (itemColliders.Length >= 1 & inventoryCanvas.activeSelf == false)
        {
            foreach (var item in itemColliders)
            {
                if (item.CompareTag("Player"))
                {
                    pickupItemCanvas.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        inventoryCanvas.SetActive(true);
                        isPickedUp = true;
                        transform.parent = inventoryCanvas.transform;
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
