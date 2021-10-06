using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int health;
    public int startHealth = 3;
    
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    
    
    void Start()
    {
        SetHealth(startHealth);
    }

    private void Update()
    {
        
    }

    public void SetHealth(int newHealth)
    {
        // Updates health to the new value. Can modify it to subtract or add or something if we want
        health = newHealth;

        // In hase of health higher than maximum health possible
        // Sets the health to maximum number of hearts, in other words, the size of the array.
        if (health > hearts.Length)
        {
            health = hearts.Length;
        }
        // In case if player should die, health reaches 0 or below
        else if (health <= 0)
        {
            Debug.Log("YOU DIEDED!");
            health = 0; // Set to 0 so the update hearts thing below gets to update to all empty
        }
        
        // Update hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].enabled = true; // or = false if we dont wanna show empty
                hearts[i].sprite = emptyHearts;

            }
        }
    }
}
