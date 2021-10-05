using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // To move the body
    private float speed = 10f;
    private Rigidbody2D body;
    
    // Other
    private bool isWalking;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Initialize body on start
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move(); // Check for movement. Move functions always in FixedUpdate or we need to use * deltaTime
    }
    
    // Basic movement script along the x and y axis
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
        
        if (horizontal > 0)
        {
            //this.transform.rotation = new Quaternion(0, 0, -45, 0);
            this.transform.rotation = Quaternion.identity;
            this.transform.Rotate(0, 0, -90);
            Debug.Log("höger");
            //this.transform.localScale = new Vector3(-1, 1, 1); // Makes the dude turn right when walking right
            isWalking = true;
        }
        // Turn left
        else if (horizontal < 0)
        {
            this.transform.rotation = Quaternion.identity;
            this.transform.Rotate(0, 0, 90);
            Debug.Log("vänster");

            //this.transform.rotation = new Quaternion(0, 0, 45, 0);

            //this.transform.localScale = new Vector3(1, 1, 1); // Makes the dude turn left when walking left
            isWalking = true;
        }
        // Standing still
        //else
        //{
            // To reset the wobble when we stop walking, making the wizard stand with both feet on ground
        //    this.transform.rotation = Quaternion.identity; // .identity means "no rotation"
        //    isWalking = false;
        //}  
        
    }


}
