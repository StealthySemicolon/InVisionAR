using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SimulationManager : MonoBehaviour
{
    public Slider timeSlider;
    public Selectable selected;
    public Collider selectedCollider;
    public Rigidbody selectedRigidbody;
    public TextMeshProUGUI selectedText;

    void SetTime(float newTime)
    {
        Time.timeScale = newTime;
        Time.fixedDeltaTime = newTime * .02f;
        timeSlider.value = newTime;
    }

    void Start()
    {
        SetTime(0);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100f))
            {
                var selectedObject = hitInfo.transform;
                var selectable = selectedObject.gameObject.GetComponent<Selectable>();
                if (selectable != null)
                {
                    if (!selectable.displayName.Equals(selected.displayName))
                    {
                        selected = selectable;
                        selectedCollider = selectable.gameObject.GetComponent<Collider>();
                        selectedRigidbody = selectable.gameObject.GetComponent<Rigidbody>();
                        RefreshSelected();
                    }
                }
            }
        }
    }

    void RefreshSelected()
    {
        selectedText.text = selected.displayName;
        foreach (var sliderController in FindObjectsOfType<PhysicSliderController>())
        {
            sliderController.RefreshValue();
        }
    }

    public void UpdateTime()
    {
        SetTime(timeSlider.value);
    }

    public void Pause()
    {
        SetTime(0);
    }

    public void Resume()
    {
        SetTime(1);
    }
}
