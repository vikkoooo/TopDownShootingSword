using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
	// To Roll
	private bool isRolling;
	
	
	// To move the body
	public float speed = 10f;
	private Rigidbody2D body; 
	private float horizontal;
	private float vertical;

	public float dashForce = 5000f;
	
	// For the mouse movement
	private Camera cam;
	private Vector2 mousePosition;

	// Other
	public bool isWalking;
	
	private void Start()
	{
		body = GetComponent<Rigidbody2D>(); // Initialize
		cam = Camera.main; // Initialize
	}

	private void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
		roll();
		// For mouse movement
		mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
		
		
		
	}

	private void FixedUpdate()
	{	
		//dont want move() and roll() to interfere with eachother
		if(!isRolling)
		Move(); // Check for movement. Move functions always in FixedUpdate or we need to use * deltaTime

		// For mouse movement. This gives us a new vector that points from our player to our mouse position
		Vector2 lookDir = mousePosition - body.position;
		// Z rotation. This gives us the angle from y axis to our new vector. Returns the angle in radians, we need to convert
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; // 90 degree offset here depending on how sprite looks
		body.rotation = angle; 	// Set the new rotation
	}

	/**
	 * Basic movement script along the x and y axis
	 */
	private void Move()
	{
		body.velocity = new Vector2(horizontal * speed, vertical * speed); 
		/*
		// Turn sprite right
		if (horizontal > 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, -90);
			isWalking = true;
		}
		// Turn sprite left
		else if (horizontal < 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, 90);
			isWalking = true;
		}
		// Turn sprite north
		else if (vertical > 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, 0);
			isWalking = true;
		}
		// Turn sprite south
		else if (vertical < 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, -180);
			isWalking = true;
		}
		// Standing still
		else
		{
		    isWalking = false;
		}  
		*/
	}

	void roll()
	{
		if (Input.GetKeyDown("space"))
		{
			isRolling = true;
			body.AddForce(transform.up * dashForce);
		}
		isRolling = false;
	}
}
