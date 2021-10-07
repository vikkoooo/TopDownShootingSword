using System.Collections;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
	// Settings
	private float timeSinceLastAttack;
	private float timeBetweenAttack = 2.4f; // How much should you be able to spam? Animation needs to finish almost?
	private float attackDuration = 2.5f; // For how long will the trigger be visible? Prefer to sync with animation

	public GameObject collider; // The collider used
	private int damage = 25;

	void Start()
	{
		timeSinceLastAttack = timeBetweenAttack; // The player dont have to wait for the first attack
		collider.SetActive(false); // Deactivate attack as default
	}

	void FixedUpdate()
	{
		// Count how long it was since the player attacked
		timeSinceLastAttack += Time.deltaTime;
	}

	void Update()
	{
		// Player attempts to attack
		if (Input.GetButtonDown("Fire1") && timeSinceLastAttack >= timeBetweenAttack)
		{
			collider.SetActive(true); // Activate the collider
			Debug.Log("Weapon swing started");

			timeSinceLastAttack = 0f;
			StartCoroutine(CheckMiss(attackDuration)); // Start timer to deactivate the collider in case of miss
		}
	}

	private IEnumerator CheckMiss(float duration)
	{
		// Wait for the attack duration
		yield return new WaitForSeconds(duration);

		// Consider miss if collider is active
		if (collider.activeSelf)
		{
			collider.SetActive(false);
			Debug.Log("Weapon swing missed");
		}
	}

	// This event is called when unity detects a collision
	private void OnTriggerEnter2D(Collider2D collidedObject)
	{	
		if (collidedObject.CompareTag("Enemy"))
		{
			collidedObject.GetComponent<Enemy>().TakeDamage(damage);
			collider.SetActive(false);
			Debug.Log("Weapon swing hit. Damage to monster");

			// Reset time between attack
			timeSinceLastAttack = 0f;
		}
	}
}