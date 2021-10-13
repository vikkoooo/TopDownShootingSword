using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    private bool isWalking;
    
    // For the score
    private GameObject scoreObj;
    private Score s;
    
    // Stats
    private int health = 100;
    private int damage = 1;
    
    // For the enemy drop
    public GameObject[] drops;
    
    private void Start()
    {
        anim = anim.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scoreObj = GameObject.Find("ScoreObject");
        s = scoreObj.GetComponent<Score>();
        s.PlayerScore += 0;
    }
    void Update()
    {
        if (rb.velocity.x!= 0 || rb.velocity.y !=0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("yVel", rb.velocity.y);
        anim.SetFloat("xVel", rb.velocity.x);
    }
    
    private void OnCollisionEnter2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.CompareTag("Player"))
        {
            collidedObject.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }    
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        GetComponentInChildren<FlashSprite>().StartFlash();
        
        if (health <= 0)
        {
            EnemyDeath();
        }
    }
    private void EnemyDeath()
    {
        Destroy(GetComponent<EnemyFollowPlayer>());
        Destroy(GetComponent<EnemyKnightAttack>());

        rb.isKinematic = true;
        anim.SetBool("isAttacking", false);
        anim.SetTrigger("enemyDied");
        
        s.PlayerScore += 1;
        
        StartCoroutine(DelayDeath());
        IEnumerator DelayDeath()
        {
            yield return new WaitForSeconds(2);
            
            // call on death drop
            GameObject drop = Instantiate(drops[Random.Range(0, drops.Length)]);
            drop.transform.position = this.transform.position;
            
            Destroy(gameObject);
        }
    }
}
