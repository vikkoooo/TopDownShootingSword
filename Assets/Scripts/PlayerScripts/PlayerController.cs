using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public Animator anim;
    private PlayerSword playerSwordScript;
    
    [SerializeField] private float playerMoveSpeed = 10f;
    [SerializeField] private float dashForce = 5000f;
    private float damageKnockBack = 5000f;

    private float inputHorizontal;
    private float inputVertical;
    private bool inputAttack;
    
    private bool inputDash;
    // private bool facingRight;
    // private bool facingLeft;
    // private bool facingUp;
    // private bool facingDown;
    
    public bool isWalking;
    
    // To Roll
    private bool isRolling;
    private KeyCode lastKeyPushed;
    
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerSwordScript = GetComponent<PlayerSword>();
    }
    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        inputAttack = Input.GetButtonDown("Fire1");
        inputDash = Input.GetKeyDown("space");
        
        if (inputHorizontal!= 0 || inputVertical !=0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("xInput", inputHorizontal);
        anim.SetFloat("yInput", inputVertical);

        
        if (inputAttack)
        {
            if (playerSwordScript.Attack())
            {
                // anim.SetTrigger("Attack");
                // Debug.Log("Animation start");
            }
        }
        if (inputDash)
        {
            
        }
    }

    private void FixedUpdate()
    {
       Move();
    }
    
    private void Move()
    {
        playerBody.velocity = new Vector2(inputHorizontal * playerMoveSpeed, inputVertical * playerMoveSpeed);
        // Turn Player right
        if (inputHorizontal > 0)
        { //Trigger animation Right
            this.transform.rotation = Quaternion.identity;
            this.transform.Rotate(0, 0, -90);
            
       
        }
        // Turn sprite left
        else if (inputHorizontal < 0)
        {
            //Trigger animation Left
            this.transform.rotation = Quaternion.identity;
            this.transform.Rotate(0, 0, 90);
            
		
        }
        // Turn sprite north
        else if (inputVertical > 0)
        {
            this.transform.rotation = Quaternion.identity;
            this.transform.Rotate(0, 0, 0);
            
		
        }
        // Turn sprite south
        else if (inputVertical < 0)
        {
            this.transform.rotation = Quaternion.identity;
            this.transform.Rotate(0, 0, -180);
            
        }
    }
}



