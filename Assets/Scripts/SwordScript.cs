using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SwordScript : MonoBehaviour
{
    public GameObject minigame;
    private Transform location;
    
    
    private void Start()
    {
        location = GameObject.FindWithTag("MinigameLocation").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Player"))
        {
            Destroy(gameObject.GetComponent<Collider2D>());
            Instantiate (minigame, location.transform);
        }    
    }
}
