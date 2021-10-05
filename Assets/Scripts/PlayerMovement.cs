using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D body;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }


}
