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

    
    private int allowedMisses = 3;
    private int numberToHit = 4;

    public int numberOfHits;
    public int numberOfMisses;

    
    // private GameObject scoreObj;
    // private Score s;
    private GameObject player;
    private int damage = 1;
    
    private void Start()
    {
        sliderToPlay = rythmBarController.GetComponent<TriggerSlider>();
        
        // scoreObj = GameObject.Find("ScoreObject");
        // s = scoreObj.GetComponent<Score>();
        // s.PlayerScore += 0;
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
        if (numberOfHits >= numberToHit)
        {
            Debug.Log("win");
            Win();
        }
        if (numberOfMisses >= allowedMisses)
        {
            Debug.Log("lose");

            Lose();
        }
        if ((numberOfHits + numberOfMisses) >= 5)
        {
            Debug.Log("ny lose");

            Lose();
        }
    }
    void Win()
    {
        Score.PlayerScore += 50;
        FindObjectOfType<AudioManager>().Play("DingPickup");
        Destroy(gameObject);
        player.GetComponent<PlayerStats>().Heal(1);
    }

    void Lose()
    {
        player.GetComponent<PlayerStats>().TakeDamage(damage);
        Destroy(gameObject);
        

        //set back player state
        //Deactivate rythmbar
        //Destroy sword
        //Take Damage
    }
}
