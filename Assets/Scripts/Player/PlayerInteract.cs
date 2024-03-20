using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private I_Interactable interactable;
    private bool isInteracting;
    private string triggerName;


    // Update is called once per frame
    void Update()
    {

        getClosestInteractableObject();

        if (isInteracting && interactable != null && interactable.GetCanInteract() == true)
        {
            interactable.Interact(triggerName);

        }

        //Debug.Log(interactable);

    }

    private void LateUpdate()
    {
        isInteracting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            interactable = other.gameObject.GetComponentInParent<I_Interactable>();
            triggerName = other.name;
        }

    }

    public void getClosestInteractableObject() {

        //Check all interactableObjects next to player
        List<GameObject> interactableObjects = new List<GameObject>();
        float interactRange = 4f; //Mainpulate this value to change how far the player has to be to interact

        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            if (collider.gameObject.CompareTag("Interactable")) { 
                interactableObjects.Add(collider.gameObject);
            }
        }

        //Check which object is the closest from all the objects near you
        GameObject closest = null;
        foreach (GameObject I_Obj in interactableObjects) {
            if (closest == null)
            {
                closest = I_Obj;
            }
            else 
            {
                if (Vector3.Distance(transform.position, I_Obj.transform.position) <
                    Vector3.Distance(transform.position, closest.transform.position)) 
                { 
                    closest = I_Obj;
                }
            }
        }

        //if there is an object near you, set it to the interactable values
        if (closest != null) {
            interactable = closest.gameObject.GetComponentInParent<I_Interactable>();
            triggerName = closest.gameObject.name;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        interactable = null;
    }

    private void OnInteract(InputValue value)
    {
        isInteracting = value.isPressed;
    }
}
