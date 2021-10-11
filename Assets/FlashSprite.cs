using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSprite : MonoBehaviour
{
    private SpriteRenderer mySprite;
    private float flashTime = 0.1f;
    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }
    
    public IEnumerator Flash()
    {
        yield return new WaitForSeconds(flashTime * 3);
        mySprite.color = Color.red;
        yield return new WaitForSeconds(flashTime);
        mySprite.color = Color.white;
        
    }
}
