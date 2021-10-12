using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private bool correctInput;
    private bool wrongInput;
    private RythmBarController controller;

    private RectTransform rectTransform;
    private Image image;
    private void Start()
    {
        controller = GameObject.Find("TimingBar").GetComponent<RythmBarController>();
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    private void Update()
    {
        correctInput = Input.GetMouseButtonDown(0);
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

        if (wrongInput)
        {
            controller.numberOfMisses++;
            //feedback to player, wrong hit
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
