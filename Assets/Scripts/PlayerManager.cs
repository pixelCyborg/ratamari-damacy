using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private PlayerControls controls;
    private int ratCount;

    public int RatCount
    {
        get
        {
            return ratCount;
        }
    }

    private void Start()
    {
        controls = GetComponentInChildren<PlayerControls>();
        Instance = this;
        ratCount = 1;
    }

    private void Update()
    {
        //Debug controls
        if(Input.GetKeyDown(KeyCode.Plus))
        {
            AddMass(5f);
        }

        if(Input.GetKeyDown(KeyCode.Minus))
        {
            AddMass(-5f);
        }
    }

    public void AddRats(int rats)
    {
        controls.AddSpeed(rats * 0.25f);
        ratCount += rats;
    }

    public void AddMass(float massDelta)
    {

    }
}
