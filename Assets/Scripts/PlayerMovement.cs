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
		Debug.Log(isWalking);
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
		// Standing still
		else
		{
		    isWalking = false;
		}  
	}
}