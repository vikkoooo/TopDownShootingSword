using System;
using System.Collections;
using UnityEngine;

public class EnemyKnightSword : MonoBehaviour
{
    [SerializeField]private int damage = 1;

    private float weaponPushBack = 30f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Vector2 attackDirection = rb.transform.position - transform.position;
	
			
            StartCoroutine(AddForceToObject());
            IEnumerator AddForceToObject()
            {
                yield return new WaitForSeconds(0.15f);
                CinemachineShake.Instance.ShakeCamera(2f, .2f);

                rb.AddForce(attackDirection.normalized * weaponPushBack, (ForceMode2D)ForceMode.Impulse);
            }
            
            
            gameObject.SetActive(false);
        }    
    }
    

   

    
    
}