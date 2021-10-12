using System;
using System.Collections;
using System.Collections.Generic;
using RythmBarScripts;
using UnityEngine;
using UnityEngine.UI;

public class RythmBarController : MonoBehaviour
{
    public GameObject rythmBarController;
    TriggerSlider sliderToPlay;
    public InstancePrefab dotSpawner;
    
    public int allowedMisses = 3;
    
    [HideInInspector] public int numberOfHits;
    [HideInInspector] public int numberOfMisses;
    
    private int numberToHit;
    
    private void Start()
    {
        // dotSpawner = rythmBarController.GetComponent<InstanceNotes>();
        sliderToPlay = rythmBarController.GetComponent<TriggerSlider>();
        
        numberToHit = 5;
        StartCoroutine(sliderToPlay.LerpSlider());
    }
    
    private void Update()
    {
        if (numberOfHits == numberToHit)
        {
            Win();
        }
        if (numberOfMisses >= allowedMisses)
        {
            Lose();
        }
    }
    void Win()
    {
        Debug.Log("You win");
        //Destroy Sword
        //Add score
        //add attackpower to Player
    }

    void Lose()
    {
        Debug.Log("You lose");

        //set back player state
        //Deactivate rythmbar
        //Destroy sword
        //Take Damage
    }
}
