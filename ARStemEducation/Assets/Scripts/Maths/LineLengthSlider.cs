using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineLengthSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 1;
        slider.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("value of slider = " + slider.value);
    }
    public float getSliderValue()
    {
        return slider.value;
    }
    public void setSliderValue(float value)
    {
        this.slider.value = value;
    }
}
