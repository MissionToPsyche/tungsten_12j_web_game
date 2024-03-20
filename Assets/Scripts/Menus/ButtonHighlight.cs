using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField]
    public AudioSource audi; //Object for controlling sounds in the script
    
    [SerializeField]
    public AudioClip hoverSound;

    [SerializeField]
    public AudioClip clickSound;


    public void onHighlight()
    {
        audi.PlayOneShot(hoverSound);
        Debug.Log("Button highlighted");
    }

    public void onClick()
    {
        audi.PlayOneShot(clickSound);
        Debug.Log("Button Clicked");
    }

}
