using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    private bool isWalking;
    private void Start()
    {
        anim = anim.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (rb.velocity.x!= 0 || rb.velocity.y !=0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("yVel", rb.velocity.y);
        anim.SetFloat("xVel", rb.velocity.x);
        
    }
}
