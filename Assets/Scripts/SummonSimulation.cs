using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSimulation : MonoBehaviour
{
    public GameObject simulationToSpawn;
    private PlacementIndicatorScript placementIndicator;

    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicatorScript>();
    }

    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject simulation = Instantiate(simulationToSpawn, placementIndicator.transform.position + new Vector3(0, 5, 0), placementIndicator.transform.rotation);
        }
    }

}
