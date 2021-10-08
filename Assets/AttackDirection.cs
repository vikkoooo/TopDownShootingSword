using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackDirection : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePosition;
    
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 lookDirection = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, lookDirection);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
