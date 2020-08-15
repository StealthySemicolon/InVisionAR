using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PhysicControlType{
    StaticFriction,
    DynamicFriction,
    Elasticity
}

public class PhysicSliderController : MonoBehaviour
{
    public TextMeshPro sliderValue;
    public Slider slider;
    public string type;

    public GameObject controlledObject { set; private get; }

    void Start()
    {
        sliderValue = GetComponent<TextMeshPro>();
    }

    public void UpdateValue()
    {
        sliderValue.text = Mathf.Round(slider.value * 100).ToString();
    }
}
