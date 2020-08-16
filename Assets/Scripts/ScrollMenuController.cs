using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollMenuController : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;

    void Start()
    {
        
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        //for (int i = 0; i < pos.Length; i++)
        //{
        //    if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
        //    {
        //        transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
        //        for (int a = 0; a < pos.Length; a++)
        //        {
        //            if (a != i)
        //            {
        //                transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.0f, 0.0f), 0.1f);
        //            }
        //        }
        //    }
        //}
    }

    public void GoToSciences()
    {
        SceneManager.LoadScene("ScienceSubjects");
    }

    public void GoToGeneralPhysics()
    {
        SceneManager.LoadScene("GeneralPhysicsSelection");
    }

    public void GoToGPDynamics()
    {
        SceneManager.LoadScene("GeneralPhysicsSelection");
    }

    public void GoToSimQuizSelection()
    {
        SceneManager.LoadScene("Sim_Quiz_Selection");
    }
}
