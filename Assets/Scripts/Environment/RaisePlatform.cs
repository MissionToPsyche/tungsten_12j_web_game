using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisePlatform : MonoBehaviour, I_Interactable
{
    private bool canInteract = true;
    [SerializeField]
    private Animation anim;

    public bool GetCanInteract()
    {
        return canInteract;
    }

    public void Interact(string triggerName)
    {
        anim.Play();
    }
}
