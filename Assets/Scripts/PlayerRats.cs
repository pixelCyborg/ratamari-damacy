using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRats : MonoBehaviour
{
    [SerializeField] Transform player;
    private float height = 0.5f;
    private float offset = 1f;

    private SphereCollider playerSphere;
    private Rigidbody playerBody;

    void Start()
    {
        if(player != null)
        {
            playerSphere = player.GetComponent<SphereCollider>();
            playerBody = player.GetComponent<Rigidbody>();

            Vector3 targetPos = player.position;
            targetPos -= (player.forward * offset);
            targetPos -= (player.up * height);
            transform.position = targetPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        offset = playerSphere.radius * 0.7f;
        height = -playerSphere.radius * 0.75f;

        Vector3 vel = playerBody.velocity.normalized;
        if (vel == Vector3.zero) vel = playerBody.transform.forward;

        Vector3 targetPos = playerBody.transform.position - vel * offset;
        targetPos.y = player.position.y + height;

        Vector3 lookAt = playerBody.position;
        lookAt.y = transform.position.y;

        transform.position = targetPos;
        transform.LookAt(lookAt);
    }
}
