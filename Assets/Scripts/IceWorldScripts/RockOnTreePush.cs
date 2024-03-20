using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockOnTreePush : MonoBehaviour, I_Interactable
{
    private Animator anim;

    public bool GetCanInteract()
    {
        return true;
    }

    public void Interact(string triggerName)
    {
        anim = GetComponentInParent<Animator>();
        anim.Play("RockPush");
    }
}
