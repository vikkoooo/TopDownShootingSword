using System;
using System.Collections;
using UnityEngine;

public class EnemyKnightSword : MonoBehaviour
{
    [SerializeField]private int damage = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Collision, player takes {damage} damage from monster");
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            gameObject.SetActive(false);
        }    
    }
}