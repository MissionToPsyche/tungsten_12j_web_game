using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDespawn : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem asteroidParticle;

    private void OnTriggerEnter(Collider other)
    {

        switch(other.tag)
        {
            case "Asteroid":
                other.transform.gameObject.SetActive(false);
                break;
        }
    }
}
