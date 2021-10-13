using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private bool correctInput;
    private RythmBarController controller;

    private RectTransform rectTransform;
    private Image image;
    
    private void Start()
    {
        controller = GameObject.FindWithTag("Minigame").GetComponent<RythmBarController>();
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        correctInput = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<AudioManager>().Play("Notehit");
        //feedback to player, enter note
        rectTransform.sizeDelta = new Vector2(20, 20);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("hit note");
            //feedback to player, hit
            controller.numberOfHits++;
            controller.numberOfMisses--;
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        rectTransform.sizeDelta = new Vector2(10, 10);
        image.color = Color.red;

        //feedback to player, missed hit
        controller.numberOfMisses++;
    }
    
}
