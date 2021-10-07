using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSlider : MonoBehaviour
{
    public Slider slider;
    public float loopDuration = 3f;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SliderPlay()
    {
        StartCoroutine(LerpSlider());
    }
    private IEnumerator LerpSlider()
    {
        slider.value = slider.minValue;
        float time = 0;
        while (time < loopDuration) 
        {
                time += Time.deltaTime / loopDuration;
                slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, time);
                yield return null;
        }
        slider.value = slider.maxValue;
    }
}
