using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void GoToInclinePlaneSim()
    {
        SceneManager.LoadScene("InclinedPlaneSim");
    }

    public void EndApplication()
    {
        Application.Quit();
    }
}
