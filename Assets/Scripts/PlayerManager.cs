using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private GameObject visual;

    public float waterAbsorbAmount = 0.01f;

    private PlayerControls controls;
    private int ratCount;
    private Rigidbody body;
    private SphereCollider col;

    public int RatCount
    {
        get
        {
            return ratCount;
        }
    }

    private void Start()
    {
        col = GetComponent<SphereCollider>();
        body = GetComponent<Rigidbody>();
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

    public void AddMass(float amount)
    {
        visual.transform.localScale += new Vector3(amount, amount, amount);
        body.mass += amount * 10f;
        col.radius += amount * 0.5f;
    }
}
