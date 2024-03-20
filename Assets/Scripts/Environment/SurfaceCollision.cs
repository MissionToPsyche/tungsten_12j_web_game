using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SurfaceCollision : MonoBehaviour
{
    [SerializeField]
    public Transform parent;

    public bool isOnLift = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnLift = true;
            other.transform.SetParent(parent);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnLift = true;
            other.transform.SetParent(parent);
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
