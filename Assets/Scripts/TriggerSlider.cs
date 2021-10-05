using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSlider : MonoBehaviour
{
    public Slider slider;
    public float loopDuration = 3f;
    
    private void Update() 
    {
        Debug.Log(slider.value);
    }
    public void SliderPlay()
    {
        StartCoroutine(LerpSlider());
    }
    private IEnumerator LerpSlider()
    {
        float time = 0;
        while (time < loopDuration) 
        {
            time += Time.deltaTime / loopDuration;
            slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, time);
            yield return null;
        }
        // slider.value = slider.maxValue;
    }
}
