using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    
    //Player
    //GameObject Player;

    // public Transform PlayerPos;
    //EnemyBehavior
    //private bool moveTowardsPlayer = false;
    
    // Stats
    private int health = 100;
    private int damage = 1;
    
    private Rigidbody2D body;
    //private float moveSpeed = 0.5f;
    
    // For the score
    private GameObject scoreObj;
    private Score s;

    
    private void Start()
    {
        //Player = GameObject.Find("Player");
        // PlayerPos = Player.transform;
        body = GetComponent<Rigidbody2D>();
        // Randomize direction on start

        scoreObj = GameObject.Find("ScoreObject");
        s = scoreObj.GetComponent<Score>();
        s.PlayerScore += 0;
    }
    

    public void TakeDamage(int amount)
    {
        health -= amount;
        GetComponentInChildren<FlashSprite>().StartFlash();
        
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Monster died");
            s.PlayerScore += 1;
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

    // void EnemyRandomMovment()
    // {
    //     int index = Random.Range(0, 4);
    //     body.velocity = directions[index] * moveSpeed;
    //     
    // }

    // void MoveTowardsPlayer()
    // {
    //     
    //     float distance = 2 * Time.deltaTime;
    //     transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, distance);
    //     
    // }
    
}
