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
	
	// To make movement access across the whole file
	private float horizontal;
	private float vertical;

	// Other
	private bool isWalking;
	
	// For the mouse movement
	private Camera cam;
	private Vector2 mousePos;

	private void Start()
	{
		body = GetComponent<Rigidbody2D>(); // Initialize body on start
		cam = Camera.main;
	}

	private void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
		
		// For mouse movement
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
	}

	private void FixedUpdate()
	{
		Move(); // Check for movement. Move functions always in FixedUpdate or we need to use * deltaTime

		// For mouse movement. This gives us a new vector that points from our player to our mouse position
		Vector2 lookDir = mousePos - body.position;
		
		// z rotation. this gives us the angle from y axis to our new vector
		// Returns the angle in radians, we need degress.
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; // add offset here depending on how sprite looks
		
		// Update rotation
		body.rotation = angle;
	}

	// Basic movement script along the x and y axis
	private void Move()
	{
		// I think its better to use velocity since moveposition is for kinetic bodys. we dont have a kinetic body
		body.velocity = new Vector2(horizontal * speed, vertical * speed); 
		//body.MovePosition(body.position + new Vector2(horizontal, vertical));

		// Turn right
		if (horizontal > 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, -90);
			isWalking = true;
		}
		// Turn left
		else if (horizontal < 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, 90);
			isWalking = true;
		}
		// Turn north
		else if (vertical > 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, 0);
			isWalking = true;
		}
		// Turn south
		else if (vertical < 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, -180);
			isWalking = true;
		}
		// TODO: lägg in 45 grader nordväst, nordöst, sydväst, sydost
		
		
		// Standing still
		else
		{
		    isWalking = false;
		}  
	}
}