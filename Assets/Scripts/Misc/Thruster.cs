using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    private ParticleSystem thruster;

    private Vector3 currentPos;
    private Vector3 previousPos;


    private void Awake()
    {
        thruster = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        previousPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifeTime = thruster.velocityOverLifetime;
        velocityOverLifeTime.x = (currentPos.x < previousPos.x) ? 10f : 0f;
        previousPos = currentPos;
    }
}
