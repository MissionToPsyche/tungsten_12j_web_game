using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SurfaceCollision : MonoBehaviour
{
    [SerializeField]
    public Transform parent;

    public bool isOnLift = false;

    public ParticleSystem ps; //Reference to animator for sinking cube

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnLift = true;

            if (ps.isPlaying)
            {
                other.transform.SetParent(null);
            }
            else 
            {
                other.transform.SetParent(parent);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnLift = true;

            if (ps.isPlaying)
            {
                other.transform.SetParent(null);
            }
            else
            {
                other.transform.SetParent(parent);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnLift = false;
            other.transform.SetParent(null);
        }
    }

}
