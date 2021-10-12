using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyTakeDamageKeepScore : MonoBehaviour
{
    // Stats
    private int health = 100;
    private int damage = 1;
    

    //private float moveSpeed = 0.5f;
    
    // For the score
    private GameObject scoreObj;
    private Score s;

    
    private void Start()
    {
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
