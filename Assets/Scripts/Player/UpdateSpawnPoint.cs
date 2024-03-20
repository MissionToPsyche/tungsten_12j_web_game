using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpawnPoint : MonoBehaviour
{

    [SerializeField]
    private PlayerSpawn pSpawn;
    [SerializeField]
    private Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pSpawn.currentSpawnPoint = spawnPoint;
            Destroy(this.gameObject);
        }
    }
}
