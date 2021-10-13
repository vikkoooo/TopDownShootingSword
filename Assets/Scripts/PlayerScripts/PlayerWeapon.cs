using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerWeapon : MonoBehaviour
{
	// Settings
	private float timeSinceLastAttack;
	[SerializeField] private float timeBetweenAttack = 0.8f; // How much should you be able to spam? Animation needs to finish almost?
	[SerializeField] private float attackDuration = 1f; // For how long will the trigger be visible? Prefer to sync with animation
	[SerializeField] private float weaponPushBack = 10f;

	public GameObject colliderObject; // The collider used
	private int damage = 25;
	
	
	
	void Start()
	{
		timeSinceLastAttack = timeBetweenAttack; // The player dont have to wait for the first attack
		colliderObject.SetActive(false); // Deactivate attack as default
	}

	void FixedUpdate()
	{
		// Count how long it was since the player attacked
		timeSinceLastAttack += Time.deltaTime;
	}
	
	public bool Attack()
	{
		// Player attempts to attack
		if (timeSinceLastAttack >= timeBetweenAttack)
		{
			colliderObject.SetActive(true); // Activate the collider

			timeSinceLastAttack = 0f;
			StartCoroutine(CheckMiss(attackDuration)); // Start timer to deactivate the collider in case of miss
			return true;
		}
		else return false;
	}
	
	private IEnumerator CheckMiss(float duration)
	{
		// Wait for the attack duration
		yield return new WaitForSeconds(duration);

		// Consider miss if collider is active
		if (colliderObject.activeSelf)
		{
			colliderObject.SetActive(false);
		}
	}

	// This event is called when unity detects a collision
	private void OnTriggerEnter2D(Collider2D collidedObject)
	{	
		if (collidedObject.CompareTag("Enemy"))
		{
			Rigidbody2D rb = collidedObject.GetComponent<Rigidbody2D>();
			Vector2 attackDirection = rb.transform.position - transform.position;
	
			
			StartCoroutine(AddForceToObject());
			IEnumerator AddForceToObject()
			{
				yield return new WaitForSeconds(0.15f);
				rb.AddForce(attackDirection.normalized * weaponPushBack, (ForceMode2D)ForceMode.Impulse);
				FindObjectOfType<AudioManager>().Play("KnockBack");
			}
			
			// collidedObject.GetComponent<EnemyTakeDamageKeepScore>().TakeDamage(damage);
			collidedObject.GetComponent<EnemyController>().TakeDamage(damage);

			colliderObject.SetActive(false);

			// Reset time between attack
			timeSinceLastAttack = 0f;
		}
	}
}
