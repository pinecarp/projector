using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isFlying;

    private float angle;
    private float bulletSpeed = 5f;

    private GameObject player;

    private Rigidbody2D rb;
    
    private Vector2 flyDirection;
    private Vector3 mousePos;
    
    private Camera mainCamera;
    
    private Variables variables;
    private Item item;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        item = gameObject.GetComponent<Item>();
        variables = GameObject.FindGameObjectWithTag("GameController").GetComponent<Variables>();
    }

    private void Update()
    {
        Fly();

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        if (isFlying)
        {
            //transform.position += transform.up * bulletSpeed * Time.deltaTime;
        }
    }

    private void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) & variables.inHand)
        {
            StartCoroutine(Flying());
        }
    }

    private IEnumerator Flying()
    {
        rb.isKinematic = false;
        item.itemCanMove = false;
        flyDirection = mousePos - transform.position;
        angle = Mathf.Atan2(flyDirection.y, flyDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        isFlying = true;
        rb.AddForce(flyDirection * bulletSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        rb.isKinematic = true;
    }
}
