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
        health = newHealth;
        
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
