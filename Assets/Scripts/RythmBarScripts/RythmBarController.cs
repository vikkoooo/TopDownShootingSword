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
    // public InstancePrefab dotSpawner;

    
    public int allowedMisses = 3;
    
    [HideInInspector] public int numberOfHits;
    [HideInInspector] public int numberOfMisses;
    
    private int numberToHit;
    
    private GameObject scoreObj;
    private Score s;
    private GameObject player;
    private int damage = 1;
    
    private void Start()
    {
        sliderToPlay = rythmBarController.GetComponent<TriggerSlider>();
        
        numberToHit = 4;
        
        scoreObj = GameObject.Find("ScoreObject");
        s = scoreObj.GetComponent<Score>();
        s.PlayerScore += 0;
        player = GameObject.FindWithTag("Player");

        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(sliderToPlay.LerpSlider());
        }
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

        s.PlayerScore += 5;
        FindObjectOfType<AudioManager>().Play("DingPickup");
        Destroy(gameObject);
        Debug.Log("You win");
        //Destroy Sword
        //Add score
        //add attackpower to Player
    }

    void Lose()
    {
        player.GetComponent<PlayerStats>().TakeDamage(damage);
        Destroy(gameObject);
        Debug.Log("You lose");

        //set back player state
        //Deactivate rythmbar
        //Destroy sword
        //Take Damage
    }
}
