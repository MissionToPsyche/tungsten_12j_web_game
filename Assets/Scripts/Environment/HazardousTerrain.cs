using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousTerrain : MonoBehaviour
{

    [SerializeField]
    private Transform Player;
    [SerializeField]
    private PlayerSpawn playerSpawn;

    private ParticleSystem pSystem;

    private PlayerSFX pSFX;


    private void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSpawn = Player.GetComponent<PlayerSpawn>();
        pSFX = Player.GetComponent<PlayerSFX>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pSFX.stopStep();
            switch (this.gameObject.tag)
            {
                case "MeteorStrike":
                    if(pSystem != null && pSystem.time > .5f && pSystem.time < 3.5f)
                    {
                        playerSpawn.SetRespawnFlagToTrue();
                    }
                    break;
                default:
                    playerSpawn.SetRespawnFlagToTrue();
                    break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.gameObject.tag)
            {
                case "MeteorStrike":
                    if (pSystem != null && pSystem.time > .5f && pSystem.time < 3.5f)
                    {
                        playerSpawn.SetRespawnFlagToTrue();
                    }
                    break;
                default:
                    playerSpawn.SetRespawnFlagToTrue();
                    break;
            }
        }
    }
}
