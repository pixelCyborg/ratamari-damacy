using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private Rigidbody body;
    private Camera cam;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Move(x, y);
    }

    private void Move(float x, float y)
    {
        Vector3 torque = Vector3.zero;
        torque += cam.transform.forward * -x;
        torque += cam.transform.right * y;

        body.AddTorque(torque * speed, ForceMode.Force);
    }
}
