using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSlider : MonoBehaviour
{
    public Slider slider;
    public float loopDuration;
    float time;
    // private AudioSource audioSrc;


    private void Start()
    {
        slider = GetComponent<Slider>();
        // audioSrc = FindObjectOfType<AudioManager>().GetComponent("Notehit") as AudioSource;

    }
    
    public IEnumerator LerpSlider()
    {
        LerpeReset();
        while (time < loopDuration)
        {
            time += Time.deltaTime / loopDuration;
            slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, time);
            // audioSrc.pitch = Mathf.Lerp(3f, 6f, time);
 
            yield return null;
        }
        LerpeReset();
    }

    void LerpeReset()
    {
        slider.value = slider.minValue;
        time = 0;
    }
    
    
    
}

