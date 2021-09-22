using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatPickup : MonoBehaviour
{
    [SerializeField] private int rats = 1;
    private bool pickedUp = false;
    private float pickUpSpeed = 8f;
    Transform playerTransform;

    private void Start()
    {
        transform.Rotate(new Vector3(0, Random.Range(-180, 180), 0));
    }

    private void Update()
    {
        if (!pickedUp) return;
        if (playerTransform == null) return;

        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * pickUpSpeed);
        transform.localScale *= 0.99f;
        transform.Rotate(new Vector3(0, 500f * Time.deltaTime, 0));

        if(Vector3.Distance(transform.position, playerTransform.position) < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pickedUp) return;
        PlayerControls playerControls = other.GetComponent<PlayerControls>();
        if(playerControls != null)
        {
            Debug.Log("Picked up a rat!");
            PlayerManager.Instance.AddRats(rats);
            pickedUp = true;
            playerTransform = other.transform;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Rats/Rat Pickup", transform.position);
        }
    }
}
