using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Health currently set to 4.
    private int health = 4;
    
    // This means the array of hearts should contain 4 objects and should be of size 4
    public Image[] hearts;
    
    void Start()
    {
        CheckHealth(); // Updates UI and checks for death
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        CheckHealth(); // Updates UI and checks for death
    }

    private void CheckHealth()
    {
        // In hase of health higher than maximum health possible
        // Sets the health to maximum number of hearts, in other words, the size of the array.
        if (health > hearts.Length)
        {
            health = hearts.Length;
        }
        // In case if player should die, health reaches 0 or below
        else if (health <= 0)
        {
            PlayerDied();
            Debug.Log("Player died");
            health = 0; // Set to 0 so the update hearts thing below gets to update to all empty
        }
        
        // Update hearts
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
        Destroy(gameObject);
        //Display highscore?
        //
    }
}
