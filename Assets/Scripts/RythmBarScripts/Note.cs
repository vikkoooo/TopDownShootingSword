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
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x + 10, rectTransform.sizeDelta.y + 10);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButton("Fire1"))
        {
            //feedback to player, hit
            FindObjectOfType<AudioManager>().Play("DingNote");
            controller.numberOfHits++;
            controller.numberOfMisses--;
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x - 10, rectTransform.sizeDelta.y - 10);
        image.color = Color.red;

        //feedback to player, missed hit
        controller.numberOfMisses++;
    }
    
}
