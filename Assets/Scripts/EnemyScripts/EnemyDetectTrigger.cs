using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<EnemyFollowPlayer>().enabled = true;
            
            Destroy(GetComponent<CircleCollider2D>());
        }
    }
}
