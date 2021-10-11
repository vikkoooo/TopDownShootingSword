using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyGuy : MonoBehaviour
{
    /* Contains
     * HEALTH
     * DMG   
     *
     *
     * 
     */
    
    
    
    // EnemyScore
    private GameObject scoreObj;
    private Score s;
    
    // EnemyMovement
    private Rigidbody2D body;
    private float speed = 0.5f;
    private List<Vector2> directions;
    
    //EnemyTakeDmg
    private int health = 100;
    private int damage = 1;
    
    
    void Start()
    {
        s = scoreObj.GetComponent<Score>();
        body = GetComponent<Rigidbody2D>();
        EnemyMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemyMovement()
    {
      
        directions = new List<Vector2>();
        directions.Add(Vector2.up);
        directions.Add(Vector2.down);
        directions.Add(Vector2.left);
        directions.Add(Vector2.right);

        int index = Random.Range(0, 4);
        body.velocity = directions[index] * speed;
    }

    void enemyDealDmg()
    {
        
        
    }
   //Enemy dealing dmg function 
    private void OnCollisionEnter2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision, player takes damage from monster");
            collidedObject.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }    
    }

    void enemyTakeDmg(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Monster died");
            
            
        }
        
    }

    void enemyDeath(int enemyScore)
    {
        enemyScore+=s.PlayerScore;
    }
    
}
