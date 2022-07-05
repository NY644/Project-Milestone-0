using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float minFleeDistance = 3.0f;
    public float maxFleeDistance = 100.0f;

    
    public float maxBravadoValue = 25;

    public float currentBravadoValue = 10;
    public float currentFleeDistance;

    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        

        float rangeOfFleeDistance = maxFleeDistance - minFleeDistance;

        float percentageOfBravado = currentBravadoValue / 
            maxBravadoValue;

        float fleeAmountInFleeRange =
            (1- percentageOfBravado) * maxFleeDistance;

        float fleeDistance = minFleeDistance + fleeAmountInFleeRange;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
