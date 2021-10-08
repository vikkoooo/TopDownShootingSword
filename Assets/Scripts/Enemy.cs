using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    private int damage = 1;

    // Movement
    private Rigidbody2D body;
    private float speed = 0.5f;
    private List<Vector2> directions;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        // Randomize direction on start
        directions = new List<Vector2>();
        directions.Add(Vector2.up);
        directions.Add(Vector2.down);
        directions.Add(Vector2.left);
        directions.Add(Vector2.right);

        int index = Random.Range(0, 4);
        body.velocity = directions[index] * speed;
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Monster died");
        }
    }

    private void OnCollisionEnter2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision, player takes damage from monster");
            collidedObject.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }    
    }


}
