using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PhysicControlType
{
    StaticFriction,
    DynamicFriction,
    Elasticity,
    Mass
}

public class PhysicSliderController : MonoBehaviour
{
    public TextMeshProUGUI sliderValue;
    Slider slider;
    public PhysicControlType type;
    private SimulationManager simManager;

    public GameObject controlledObject { set; private get; }

    void Start()
    {
        slider = GetComponent<Slider>();
        simManager = FindObjectOfType<SimulationManager>();
    }

    public void RefreshValue()
    {
        var matToImport = simManager.selectedCollider.material;
        var rbToImport = simManager.selectedRigidbody;
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
            case PhysicControlType.Mass:
                if (rbToImport == null)
                {
                    slider.interactable = false;
                    slider.value = 0;
                    break;
                }
                slider.interactable = true;
                slider.value = rbToImport.mass;
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
        var rbToUpdate = simManager.selectedRigidbody;
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
            case PhysicControlType.Mass:
                if (rbToUpdate == null)
                    break;
                rbToUpdate.mass = slider.value;
                break;
        }
    }
}
