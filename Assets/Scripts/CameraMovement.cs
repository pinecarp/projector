using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    
    [SerializeField] private GameObject character;

    private void Update()
    {
        Vector3 characterPos = character.transform.position;

        transform.position = Vector3.Lerp(transform.position, new Vector3(characterPos.x, characterPos.y, 0), speed * Time.deltaTime);
    }
}
