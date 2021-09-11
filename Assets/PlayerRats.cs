using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRats : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float height = 0.5f;
    [SerializeField] float offset = 1f;

    private SphereCollider playerSphere;
    private Rigidbody playerBody;

    // Start is called before the first frame update
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
        if (playerBody.velocity.magnitude > 0.01f)
        {
            Vector3 vel = playerBody.velocity.normalized;
            Vector3 targetPos = playerBody.transform.position - vel * offset;
            targetPos.y = player.position.y + height;

            Vector3 lookAt = playerBody.position;
            lookAt.y = transform.position.y;

            transform.position = targetPos;
            transform.LookAt(lookAt);
        }
    }
}
