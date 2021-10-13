using System;
using System.Collections;
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
            CinemachineShake.Instance.ShakeCamera(2f, .2f);
            
            Destroy(gameObject.GetComponent<Collider2D>());
            Instantiate (minigame, location.transform);
            
            StartCoroutine(DelayDestroy());
            IEnumerator DelayDestroy()
            {
                yield return new WaitForSeconds(4);
                Destroy(gameObject);
            }
        }    
    }
}
