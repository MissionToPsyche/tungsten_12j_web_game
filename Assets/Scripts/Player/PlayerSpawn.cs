using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer mesh;
    [SerializeField]
    private MeshRenderer hat;
    [SerializeField]
    private Player3DMovement movement;
    [SerializeField]
    private ParticleSystem particle;
    public Transform currentSpawnPoint;

    [SerializeField]
    private AudioSource RespawnAudio;
    private bool playOnce = false;

    private bool respawnFlag = false;

    private void Update()
    {
        if (respawnFlag == true) {

            if (!playOnce)
            {
                RespawnAudio.Play();
                playOnce = true;
            }

            if (this.transform.position == currentSpawnPoint.position)
            {
                if (particle.isPlaying == false)
                {
                    particle.Play();
                    this.transform.parent = null;
                }
                if (particle.time >= 1.5f)
                {
                    mesh.enabled = true;
                    hat.enabled = true;
                }
                if (particle.time >= 1.9f)
                {
                    playOnce = false;

                    particle.Stop();
                    respawnFlag = false;
                    movement.enabled = true;
                }
            }
            else
            {
                movement.enabled = false;
                mesh.enabled = false;
                hat.enabled = false;
                
                if (particle.isPlaying == false)
                {
                    particle.Play();
                }
                if (particle.time >= 1.9f)
                {
                    
                    particle.Stop();
                    this.transform.position = currentSpawnPoint.position;
                }
            }
        }
    }

    public void SetRespawnFlagToTrue()
    {
       respawnFlag = true;
    }
}