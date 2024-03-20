using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SatelliteCollect : MonoBehaviour, I_Interactable
{

    [SerializeField]
    private GameObject[] LockedElements;

    [SerializeField]
    private string partName;
    [SerializeField]
    private string partDescription;
    [SerializeField]
    private Sprite partImage;

    [SerializeField]
    private Transform nextPiece;

    [SerializeField]
    private GameObject objectiveMarker;
    [SerializeField]
    private GameObject UIController;

    [SerializeField]
    private GameObject gameManager;


    bool isInteractable = true;

    public void activateElements() 
    {

        gameObject.SetActive(false); //turn part invisible

        //Create a new satellite part based on object name and description and append it to the collected satellite parts list
        SatellitePart newPart = new SatellitePart(partName, partDescription, partImage);
        gameManager.GetComponent<GameManager>().setNewSatellitePart(newPart);

        //Start animation
        UIController.GetComponent<UIController>().openSatelliteCollect();

        if (nextPiece != null) {
            objectiveMarker.GetComponent<ObjectiveMarker>().setTarget(nextPiece);
        }

        //Make locked elements active
        foreach (GameObject element in LockedElements)
        {
            element.SetActive(true);
        }
    }

    public bool GetCanInteract()
    {
        return isInteractable; 
    }

    public void Interact(string triggerName)
    {

        activateElements();
        isInteractable = false;
    }
}
