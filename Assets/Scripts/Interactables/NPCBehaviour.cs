using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour, I_Interactable
{

    [SerializeField]
    private string NPCName;

    [SerializeField]
    private GameObject UIController;

    [SerializeField]
    private string[] NPCDialouge;

    private int conversationIndex = 0;
    private bool canInteract = true;

    public void startDialouge() {

        //Set UI Values
        setNextDialouge();

        //Open UI 
        UIController.GetComponent<UIController>().openDialouge(this);
    }

    //returns if there is more dialouge or not
    public bool checkDialouge()
    {

        //Set next dialouge if there is one
        if (conversationIndex < NPCDialouge.Length)
        {
            return true;
        }
        //If no dialouge, reset index value and close UI
        else
        {
            conversationIndex = 0;
            canInteract = true;
            return false;
        }

    }

    public void setNextDialouge() 
    {

        UIController.GetComponent<UIController>().setNewDialouge(NPCName, NPCDialouge[conversationIndex]);
        conversationIndex++;
    
    }

    public bool GetCanInteract()
    {
        return canInteract;
    }

    public void setNPCIsInteractable(bool isInteractable)
    {
        canInteract = isInteractable;
    }

    public void Interact(string triggerName)
    {
        //Set UI Values
        setNextDialouge();

        //Open UI 
        UIController.GetComponent<UIController>().openDialouge(this);

        canInteract = false;
    }



}
