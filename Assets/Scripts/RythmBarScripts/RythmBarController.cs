using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmBarController : MonoBehaviour
{
    private TriggerSlider slider;
    private InstanceNotes instanceNotes;
    public int allowedMisses = 3;
    
    [HideInInspector] public int numberOfHits;
    [HideInInspector] public int numberOfMisses;
    private int numberToHit;
    
    private void Start()
    {
        instanceNotes = GetComponent<InstanceNotes>();
        numberToHit = instanceNotes.numberToCreate;
        numberOfHits = 0;
        numberOfMisses = 0;
        slider.SliderPlay();
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
