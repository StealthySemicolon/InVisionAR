using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBetweenSim_Quiz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void GoToGPDynamics()
    {
        SceneManager.LoadScene("GeneralPhysicsSelection");
    }
}
