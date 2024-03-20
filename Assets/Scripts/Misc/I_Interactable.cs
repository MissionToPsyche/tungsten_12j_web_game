using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Interactable
{
    public bool GetCanInteract();
    public void Interact(string triggerName);
}
