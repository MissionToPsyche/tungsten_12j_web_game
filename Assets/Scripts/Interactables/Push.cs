using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Push : MonoBehaviour, I_Interactable
{
    [Header("Box 1")]
    [SerializeField]
    private List<string> Platform1Keys;
    [SerializeField]
    private Transform[] Platform1Values;
    [SerializeField]
    private Transform Platform1StartPostion;
    [SerializeField]
    private Transform[] Platform1StopPositions;


    [Header("Box 2")]
    [SerializeField]
    private List<string> Platform2Keys;
    [SerializeField]
    private Transform[] Platform2Values;
    [SerializeField]
    private Transform Platform2StartPosition;
    [SerializeField]
    private Transform[] Platform2StopPositions;

    Dictionary<string, Transform> boxOneKVP = new Dictionary<string, Transform>();
    Dictionary<string, Transform> boxTwoKVP = new Dictionary<string, Transform>();

    private bool isPushing = false;
    private bool canInteract = true;

    private int currentStopBox2 = 0;

    string boxKey = string.Empty;

    private bool boxOnePushed = false;
    private bool boxTwoPushed = false;  

    public bool GetCanInteract()
    {
        return canInteract;
    }

    public void Interact(string triggerName)
    {
        Debug.Log("Interacted");
        isPushing = true;
        canInteract = false;
        boxKey = triggerName;

    }

    private void Start()
    {
        
        int i = 0;
        foreach(string key in Platform1Keys)
        {
            boxOneKVP.Add(key, Platform1Values[i]);
            i++;
        }
        i = 0;
        foreach (string key in Platform2Keys)
        {
            boxTwoKVP.Add(key, Platform2Values[i]);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(boxKey)
        {
            case "InteractBox1":
                PushBox(boxOneKVP, Platform1StopPositions.First());
                StopBox(boxOneKVP, Platform1StopPositions.First());
                break;
            case "InteractBox2":
                if(boxOnePushed)
                {
                    PushBox(boxTwoKVP, Platform2StopPositions.ElementAt(1));
                    StopBox(boxTwoKVP, Platform2StopPositions.ElementAt(1));
                }
                else
                {
                    PushBox(boxTwoKVP, Platform2StopPositions.ElementAt(0));
                    StopBox(boxTwoKVP, Platform2StopPositions.ElementAt(0));
                }
                break;
            case "InteractBox1Reset":
                ResetBox(boxOneKVP, Platform1StartPostion);
                break;
            case "InteractBox2Reset":
                ResetBox(boxTwoKVP, Platform2StartPosition);
                break;
        }
    }

    private void StopBox(Dictionary<string, Transform> kvp, Transform stop)
    {
        if (kvp[boxKey].position == stop.position)
        {
            currentStopBox2++;
            isPushing = false;
            canInteract = true;
        }
    }

    private void PushBox(Dictionary<string, Transform> kvp, Transform stop)
    {
        if (isPushing)
        {
            kvp[boxKey].position = Vector3.Lerp(kvp[boxKey].position, stop.position, Time.deltaTime);
            if(boxKey == "InteractBox1")
            {
                boxOnePushed = true;
            }
            
        }
    }

    private void ResetBox(Dictionary<string, Transform> kvp, Transform start)
    {
        if (isPushing)
        {
            kvp[boxKey].position = Vector3.Lerp(kvp[boxKey].position, start.position, Time.deltaTime);
            if(boxKey == "InteractBox2")
            {
                currentStopBox2 = 0;
            }
        }
    }
}
