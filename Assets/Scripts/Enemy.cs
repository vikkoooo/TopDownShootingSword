using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    
    //Player
    GameObject Player;

    public Transform PlayerPos;
    //EnemyBehavior
    private bool moveTowardsPlayer = false;
    
    
    // Stats
    private int health = 100;
    private int damage = 1;

    // Movement
    private Rigidbody2D body;
    private float moveSpeed = 0.5f;
    private List<Vector2> directions;
    
    private void Start()
    { 
        Player = GameObject.Find("Player");
        PlayerPos = Player.transform;
        body = GetComponent<Rigidbody2D>();
        // Randomize direction on start
        directions = new List<Vector2>();
        directions.Add(Vector2.up);
        directions.Add(Vector2.down);
        directions.Add(Vector2.left);
        directions.Add(Vector2.right);

        
      
    }

    private void Update()
    {
        float dist = Vector3.Distance(PlayerPos.position, transform.position);
        if(dist<6||moveTowardsPlayer==true)
        {
            moveTowardsPlayer = true;
        if (moveTowardsPlayer == true)
        {
            MoveTowardsPlayer();
            
        }
        }
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

    void EnemyRandomMovment()
    {
        int index = Random.Range(0, 4);
        body.velocity = directions[index] * moveSpeed;
        
    }

    void MoveTowardsPlayer()
    {
        
        float distance = 2 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, distance);
        
    }
    
}
