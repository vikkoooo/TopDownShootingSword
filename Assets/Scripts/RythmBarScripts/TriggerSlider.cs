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

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    
    public IEnumerator LerpSlider()
    {
        LerpeReset();
        while (time < loopDuration)
        {
            time += Time.deltaTime / loopDuration;
            slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, time);
 
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

