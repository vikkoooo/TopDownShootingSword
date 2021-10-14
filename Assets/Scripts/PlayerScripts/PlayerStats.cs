using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Health currently set to 4.
    private int health = 10;
    
    // This means the array of hearts should contain 4 objects and should be of size 4
    public Image[] hearts;
    
    void Start()
    {
        CheckHealth(); // Updates UI and checks for death
    }
    
    public void TakeDamage(int amount)
    {
        GetComponentInChildren<FlashSprite>().StartFlash();
        FindObjectOfType<AudioManager>().Play("PlayerGrunt");
        CinemachineShake.Instance.ShakeCamera(2f, .2f);

        health -= amount;
        CheckHealth(); // Updates UI and checks for death
    }

    public void Heal(int amount)
    {
        health += amount;
        CheckHealth();
    }

    private void CheckHealth()
    {
        // Overload check
        if (health > hearts.Length)
        {
            health = hearts.Length;
            UpdateHearts();
        }
        
        // In case if player should die, health reaches 0 or below
        if (health <= 0)
        {
            health = 0; // Set to 0 so the update hearts thing below gets to update to all empty
            UpdateHearts();
            PlayerDied();
            return;
        }
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void PlayerDied()
    {
        // Destroy(gameObject);
        MenuManager.YouDied();
    }
}
