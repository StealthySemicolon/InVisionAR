using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSimulation : MonoBehaviour
{
    public GameObject simRef;
    public GameObject placementIndicatorObject;
    private PlacementIndicatorScript placementIndicator;
    private bool simStarted;
    public GameObject canvas;

    void Start()
    {
        placementIndicator = placementIndicatorObject.GetComponent<PlacementIndicatorScript>();
        simStarted = false;
        simRef.SetActive(false);
    }

    void Update()
    {
        if (!simStarted)
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                simRef.transform.SetPositionAndRotation(placementIndicator.transform.position, placementIndicator.transform.rotation);
                placementIndicatorObject.SetActive(false);
                simRef.SetActive(true);
                canvas.SetActive(true);

                simStarted = true;
            }
    }

}
