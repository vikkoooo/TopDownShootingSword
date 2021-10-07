using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmBarController : MonoBehaviour
{
    public GameObject rythmBarController;
    TriggerSlider sliderToPlay;
    public InstanceNotes dotSpawner;
    
    public int allowedMisses = 3;
    
    [HideInInspector] public int numberOfHits;
    [HideInInspector] public int numberOfMisses;
    
    private int numberToHit;
    
    private void Start()
    {
        // dotSpawner = rythmBarController.GetComponent<InstanceNotes>();
        sliderToPlay = rythmBarController.GetComponent<TriggerSlider>();
        
        numberOfHits = 0;
        numberOfMisses = 0;
        numberToHit = dotSpawner.numberToCreate;
        
        sliderToPlay.SliderPlay();
        dotSpawner.InstanceObjects();
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
        //Destroy Sword
        //Add score
        //add attackpower to Player
    }

    void Lose()
    {   //set back player state
        //Deactivate rythmbar
        //Destroy sword
        //Take Damage
    }
}
