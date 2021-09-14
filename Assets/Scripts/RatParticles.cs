using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatParticles : MonoBehaviour
{
    ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();   
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.MainModule module = particles.main;
        module.maxParticles = PlayerManager.Instance.RatCount - 1;
    }
}
