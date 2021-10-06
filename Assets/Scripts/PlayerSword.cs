using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
	private float timeSinceLastAttack = 0f;
	public float timeBetweenAttack = 0.1f;

	public Transform attackStartPos;
	public float attackRange = 0.5f;
	public int damage = 25;

	// Update is called once per frame
	void Update()
	{
		// Count how long it was since the player attacked
		timeSinceLastAttack -= Time.deltaTime;

		// Player attemts to attack
		if (Input.GetButton("Fire1"))
		{
			// Check that he actually is allowed to can attack
			if (timeSinceLastAttack <= 0)
			{
				// Start the attack
				{
					Debug.Log("attack körs");
					Collider2D[] enemiesToDamage =
							Physics2D.OverlapCircleAll(attackStartPos.position, attackRange);

					// Check for hit
					for (int i = 0; i < enemiesToDamage.Length; i++)
					{
						enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
						Debug.Log("träff");
					}
				}
				// Reset time between attack
				timeSinceLastAttack = timeBetweenAttack;
			}
		}
	}


	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackStartPos.position, attackRange);
	}
}