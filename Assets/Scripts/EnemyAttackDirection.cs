using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyAttackDirection : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        Vector2 lookDirection = target.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, lookDirection);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
