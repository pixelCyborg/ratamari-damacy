using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public static float CurrentSpeed;
    [SerializeField] private float debugCurrentSpeed;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float angularVelocityMax = 100f;

    private Rigidbody body;
    private Camera cam;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = angularVelocityMax;
        cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        if(body != null)
        {
            CurrentSpeed = body.angularVelocity.magnitude;
            debugCurrentSpeed = CurrentSpeed;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Move(x, y);
    }

    private void Move(float x, float y)
    {
        Vector3 torque = Vector3.zero;
        torque += cam.transform.forward * -x;
        torque += cam.transform.right * y;

        body.AddTorque(torque.normalized * speed * (Time.deltaTime * 50f), ForceMode.Force);
    }

    public void AddSpeed(float change)
    {
        speed += change;
    }
}
