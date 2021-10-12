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

    private void Update()
    {
        correctInput = Input.GetMouseButtonDown(0);
        if (Input.GetMouseButtonUp(0))
        {
            correctInput = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //feedback to player, enter note
        rectTransform.sizeDelta = new Vector2(20, 20);
        Debug.Log("Entered trigger");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (correctInput)
        {
            Debug.Log("hit note");
            //feedback to player, hit
            controller.numberOfHits++;
            Destroy(gameObject);
        }
        
        Debug.Log("staying on trigger");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        rectTransform.sizeDelta = new Vector2(10, 10);
        image.color = Color.red;

        //feedback to player, missed hit
        controller.numberOfMisses++;
        Debug.Log("Missed trigger");
    }
}
