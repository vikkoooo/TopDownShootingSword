using UnityEngine;
using UnityEngine.UI;

public class triggerSlider : MonoBehaviour
{
    public float sliderSpeed = 0.02f;
    public Slider slider;

    private void Start() {
        slider.onValueChanged.AddListener( delegate(float arg0) {SliderValueCheck();});
    }
    private void Update() {
        SliderValueCheck();
    }

    public void SliderPlay()
    {
        while (slider.value<slider.maxValue) {
            slider.value += sliderSpeed;
            Debug.Log("In the loop");
        }
        slider.value = slider.minValue;
        Debug.Log("Slider Reset");
    }

    public void SliderValueCheck()
    {
        Debug.Log(slider.value);
    }
}
