using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveMarker : MonoBehaviour
{
    [SerializeField]
    private Image markerImage;
    
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject distanceText;

    private float minX, maxX, minY, maxY;

    private void Start()
    {
        //Caluclate constraints for the marker's position on the canvas
        minX = markerImage.GetPixelAdjustedRect().width / 2;
        maxX = Screen.width - minX;

        minY = markerImage.GetPixelAdjustedRect().height / 2;
        maxY = Screen.height - minY;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Camera.main.WorldToScreenPoint(target.position);

        

        //Check to see if waypoint is behind the player and put it on the edges of the screen if it is
        if (Vector3.Dot((target.position - Camera.main.transform.position), Camera.main.transform.forward) < 0) {
            if (targetPos.x < (Screen.width / 2))
            {
                targetPos.x = maxX;
            }
            else {
                targetPos.x = minX;
            }
        }

        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        this.transform.position = targetPos;

        int distance = Convert.ToInt32(Vector3.Distance(target.position, Player.position));
        distanceText.gameObject.GetComponent<TextMeshProUGUI>().SetText(distance.ToString() + "m");
    }

    //Setter Methods
    public void setTarget(Transform newTarget) 
    {
        this.target = newTarget;
    }

}
