using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("DingPickup");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("DingNote");

        }
    }
}
