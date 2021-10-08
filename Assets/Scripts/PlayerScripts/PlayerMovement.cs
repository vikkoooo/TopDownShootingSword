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
	private KeyCode lastKeyPushed;
	
	// To move the body
	public float speed = 10f;
	private Rigidbody2D body; 
	private float horizontal;
	private float vertical;
	private float knockBack = -5000f;
	
	//Should be moved to player-control script?
	public Animator anim;

	public float dashForce = 5000f;
	
	// For the mouse movement
	private Camera cam;
	private Vector2 mousePosition;

	// Other
	public bool isWalking;
	
	private void Start()
	{
		body = GetComponent<Rigidbody2D>();
		// body// Initialize
		cam = Camera.main; // Initialize
	}

	private void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

		if (horizontal!= 0 || vertical !=0)
		{
			isWalking = true;
		}
		else
		{
			isWalking = false;
		}
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
		/*body.rotation = angle; 	// Set the new rotation*/
	}
	
	
	//Basic movement script along the x and y axis
	private void Move()
	{
		body.velocity = new Vector2(horizontal * speed, vertical * speed);
		// Turn sprite right
		if (horizontal > 0)
		{ //Trigger animation Right
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, -90);
			
		}
		// Turn sprite left
		else if (horizontal < 0)
		{
			//Trigger animation Left
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, 90);
		
		}
		// Turn sprite north
		else if (vertical > 0)
		{
			//Trigger animation Up
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, 0);
		
		}
		// Turn sprite south
		else if (vertical < 0)
		{
			this.transform.rotation = Quaternion.identity;
			this.transform.Rotate(0, 0, -180);
		}
	}

	void roll()
	{	
		//Kanske ändra till musriktning
		
		if (Input.GetKeyDown(KeyCode.W))
		{
			isWalking = true;
			lastKeyPushed = KeyCode.W;
		}
		
		if (Input.GetKeyDown(KeyCode.A))
		{
			isWalking = true;
			lastKeyPushed = KeyCode.A;
		}
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			isWalking = true;
			lastKeyPushed = KeyCode.S;
		}
		
		if (Input.GetKeyDown(KeyCode.D))
		{
			isWalking = true;
			lastKeyPushed = KeyCode.D;
		}
		
		if (Input.GetKeyDown("space"))
		{
			if (isWalking == true)
			{
				isRolling = true;
				
				if (lastKeyPushed == KeyCode.W)
				{
					body.AddForce(Vector2.up * dashForce);
				}
				else if (lastKeyPushed == KeyCode.A)
				{
					
					
					body.AddForce(Vector2.left * dashForce);
				}
				else if (lastKeyPushed == KeyCode.S)
				{
					
					
					body.AddForce(Vector2.down * dashForce);
				}
				
				else if (lastKeyPushed == KeyCode.D)
				{
					
					
					body.AddForce(Vector2.right * dashForce);
				}
				
				
				
			}
		}
		isRolling = false;

		if (Input.GetKeyUp(KeyCode.W))
		{
			isWalking = false;

		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			isWalking = false;

		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			isWalking = false;

		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			isWalking = false;

		}
		
	}
}
