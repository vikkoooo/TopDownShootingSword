using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlashSprite : MonoBehaviour
{
    private SpriteRenderer mySprite;
    private float flashTime = 0.1f;
    
    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        mySprite.color = Color.white;
    }


    public void StartFlash()
    {
        StartCoroutine(Flash());
    }
    
    private IEnumerator Flash()
    {
        yield return new WaitForSeconds(flashTime * 2);
        gameObject.transform.localScale += new Vector3(.2f, .2f, 0f);
        mySprite.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        gameObject.transform.localScale -= new Vector3(.2f, .2f, 0f);
        mySprite.color = Color.white;
    }
}
