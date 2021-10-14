using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    private bool isWalking;

    [SerializeField]
    private float waitFollowOnHit;
    private EnemyFollowPlayer followPlayerScript;
    // For the score
    // private GameObject scoreObj;
    // private Score s;
    private PlayerController playerController;
    
    // Stats
    private int health = 100;
    private int damage = 1;
    
    // For the enemy drop
    public GameObject[] drops;
    
    private void Start()
    {
        anim = anim.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        followPlayerScript = GetComponent<EnemyFollowPlayer>();
        // scoreObj = GameObject.Find("ScoreObject");
        // s = scoreObj.GetComponent<Score>();
        // s.PlayerScore += 0;
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
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
        
        if (collidedObject.gameObject.CompareTag("Player") && health>0)
        {
            collidedObject.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
    public void TakeDamage(int amount)
    {
        FindObjectOfType<AudioManager>().Play("EnemyGrunt");
        health -= amount;
        GetComponentInChildren<FlashSprite>().StartFlash();
        rb.velocity = Vector2.zero;
        

        if (health <= 0)
        {
            EnemyDeath();
        }
        else
        {
            PausFollowPlayer();
        }
    }
    
    private void PausFollowPlayer(){
        
        StartCoroutine(DeactivateFollowPlayer());
        IEnumerator DeactivateFollowPlayer()
        {
            isWalking = false;
            followPlayerScript.enabled = false;
            yield return new WaitForSeconds(waitFollowOnHit);                
            followPlayerScript.enabled = true;
        }
    }
    
    private void EnemyDeath()
    {
        Destroy(GetComponent<BoxCollider2D>());
        rb.Sleep();
        rb.isKinematic = true;
        Destroy(GetComponent<EnemyKnightAttack>());
        Destroy(followPlayerScript);
        
        
        anim.SetBool("isAttacking", false);
        anim.SetTrigger("enemyDied");
        
        playerController.ShowTextPopUp("100");
        Score.PlayerScore += 100;
        
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
