using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private float winMass = 60f;
    [SerializeField] Rigidbody body;

    private void CheckPlayerMass()
    {
        if(body.mass >= winMass)
        {
            Win();
        }
    }

    private void Win()
    {

    }
}
