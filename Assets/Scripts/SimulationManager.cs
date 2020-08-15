using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationManager : MonoBehaviour
{
    public Slider timeSlider;
    
    void SetTime(float newTime) {
        Time.timeScale = newTime;
        Time.fixedDeltaTime = newTime * .02f;
        timeSlider.value = newTime;
    }
    
    void Start()
    {
        SetTime(0);
    }

    public void UpdateTime() {
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
