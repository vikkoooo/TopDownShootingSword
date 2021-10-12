using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    private float force = 2f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown("space")){
            
            rb.AddForce(-transform.forward * force);
            
        }
    }
}
