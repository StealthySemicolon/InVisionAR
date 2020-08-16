using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void GoToSubjectSelection()
    {
        SceneManager.LoadScene("SubjectSelection");
    }

    public void EndApplication()
    {
        Application.Quit();
    }
}
