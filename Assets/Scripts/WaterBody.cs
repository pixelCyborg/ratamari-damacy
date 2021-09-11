using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBody : MonoBehaviour
{
    [SerializeField] private bool enableEvaporate = true;
    // this is currently unrelated to water object Y transform, sorry
    [SerializeField] private float waterLevel = 0.50f;
    [SerializeField] private float evaporationRate = 0.01f;
    [SerializeField] private float minWaterLevel = 0.01f;
    // controls how often water evaporates
    [SerializeField] private float evapTimeStep = 1.0;
    private bool drained = false;

    // Start is called before the first frame update
    void Start()
    {
        // evaporation begins 1s after Start()
        if (enableEvaporate) InvokeRepeating("EvaporateWater", 1.0f, evapTimeStep);
    }

    void EvaporateWater() 
    {
        // decrease water level until it can't be decreased past the minimum
        if (waterLevel > minWaterLevel) 
        {
            waterLevel -= evaporationRate;
            transform.localScale -= new Vector3(0f, evaporationRate, 0f);
        } 
        else 
        {
            drained = true;
            // would it be awful if I just... CancelInvoke('EvaporateWater')
        }
    }

    /* what's your plan for water bodies? My current implementation wouldnt work with 
     this method since having the collider to not trigger makes it a physical obstacle...
     feel free to suggest something better; the "fake" water object is just my naive implementation.

     void OnCollisionStay(Collision collisionInfo)
     { 
         if (collisionInfo.gameObject.name == "Player") 
         {
             Debug.Log("ball in water");
         }

     }
     */
}
