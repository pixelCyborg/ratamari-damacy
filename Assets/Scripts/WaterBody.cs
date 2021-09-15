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
    [SerializeField] private float evapTimeStep = 5.0f;
    private bool drained = false;

    // Start is called before the first frame update
    void Start()
    {
        // evaporation begins 1s after Start()
        if (enableEvaporate) InvokeRepeating("Evaporation", 1.0f, evapTimeStep);
    }

    void Evaporation() 
    {
        if (!drained) RemoveWater(evaporationRate);
    }

    void RemoveWater(float drainAmount) {

        if ((waterLevel - drainAmount) > minWaterLevel) 
        {
            waterLevel -= drainAmount;
            transform.localScale -= new Vector3(0f, drainAmount, 0f);
        }
        else 
        {
            drained = true;
            CancelInvoke("Evaporation");
            Debug.Log("All water gone");
            Destroy(gameObject);
        }
    }

    /* what's your plan for water bodies? My current implementation wouldnt work with 
     this method since having the collider to not trigger makes it a physical obstacle...
     feel free to suggest something better; the "fake" water object is just my naive implementation.

    //There is a similar function for Triggers called OnTriggerStay I believe! Although it takes a Collider rather
    //than collision as a parameter, I think it work for us in this instance!
    //So we can just Run evaporate water every time that function is called, I'll make a public method in the player
    //object called AddMass or something so that we can "siphon" the water level value into the player

     void OnCollisionStay(Collision collisionInfo)
     { 
         if (collisionInfo.gameObject.name == "Player") 
         {
             Debug.Log("ball in water");
         }

     }
     */
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // is it expensive to put this here? probably
            PlayerManager player = other.GetComponent<PlayerManager>();
            if (!drained) 
            {
                RemoveWater(player.waterAbsorbAmount);
                player.AddMass(0.01f);
            }
        }
    }
}
