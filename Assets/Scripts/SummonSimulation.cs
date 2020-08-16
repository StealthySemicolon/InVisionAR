using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSimulation : MonoBehaviour
{
    public GameObject simRef;
    public GameObject placementIndicatorObject;
    private PlacementIndicatorScript placementIndicator;
    private bool simStarted = false;

    void Start()
    {
        placementIndicator = placementIndicatorObject.GetComponent<PlacementIndicatorScript>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !simStarted)
        {
            simRef.transform.SetPositionAndRotation(placementIndicator.transform.position, placementIndicator.transform.rotation);
            placementIndicatorObject.SetActive(false);
            simRef.SetActive(true);

            simStarted = true;
        }
    }

}
