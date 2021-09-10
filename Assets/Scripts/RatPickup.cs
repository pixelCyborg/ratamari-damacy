using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatPickup : MonoBehaviour
{
    [SerializeField] private int rats = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerControls playerControls = other.GetComponent<PlayerControls>();
        if(playerControls != null)
        {
            Debug.Log("Picked up a rat!");
            playerControls.AddSpeed(rats * 0.2f);
            Destroy(gameObject);
        }
    }
}
