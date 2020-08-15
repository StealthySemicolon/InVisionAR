using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PhysicControlType
{
    StaticFriction,
    DynamicFriction,
    Elasticity
}

public class PhysicSliderController : MonoBehaviour
{
    public TextMeshProUGUI sliderValue;
    Slider slider;
    public PhysicControlType type;
    public SimulationManager simManager;

    public GameObject controlledObject { set; private get; }

    void Start()
    {
        slider = GetComponent<Slider>();
        simManager = FindObjectOfType<SimulationManager>();
    }

    public void RefreshValue()
    {
        var matToImport = simManager.selectedCollider.material;
        switch (type)
        {
            case PhysicControlType.StaticFriction:
                slider.value = matToImport.staticFriction;
                break;
            case PhysicControlType.DynamicFriction:
                slider.value = matToImport.dynamicFriction;
                break;
            case PhysicControlType.Elasticity:
                slider.value = matToImport.bounciness;
                break;
        }

        string newText = slider.value.ToString();
        sliderValue.text = newText.Substring(0, Mathf.Min(newText.Length, 5));
    }

    public void UpdateValue()
    {
        string newText = slider.value.ToString();
        sliderValue.text = newText.Substring(0, Mathf.Min(newText.Length, 5));

        var matToUpdate = simManager.selectedCollider.material;
        switch (type)
        {
            case PhysicControlType.StaticFriction:
                matToUpdate.staticFriction = slider.value;
                break;
            case PhysicControlType.DynamicFriction:
                matToUpdate.dynamicFriction = slider.value;
                break;
            case PhysicControlType.Elasticity:
                matToUpdate.bounciness = slider.value;
                break;
        }
    }
}
