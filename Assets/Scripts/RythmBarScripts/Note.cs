using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private bool correctInput;
    private bool wrongInput;
    private RythmBarController controller;

    private void Start()
    {
        controller = GetComponent<RythmBarController>();
    }

    private void Update()
    {
        correctInput = Input.GetKeyDown("fire1");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Staying on trigger");
        if (correctInput)
        {
            //feedback to player, hit
            controller.numberOfHits++;
            Destroy(gameObject);
        }

        if (wrongInput)
        {
            controller.numberOfMisses++;
            //feedback to player, wrong hit
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        controller.numberOfMisses++;
        //feedback to player, missed hit
    }
}
