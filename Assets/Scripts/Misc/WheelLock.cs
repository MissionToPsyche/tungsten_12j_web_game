using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelLock : MonoBehaviour, I_Interactable
{

    [SerializeField]
    private string correctLetter = "P";

    [SerializeField]
    private Transform wheelLock;

    [SerializeField]
    private float rotationSpeed = 1f;

    private bool interacting = true;

    private float tempRotation;

    void Start()
    {
        tempRotation = wheelLock.localRotation.x;
    }

    public void Interact(string triggerName)
    {
        interacting = false;
        float currentAngle = tempRotation;
        float targetAngle = tempRotation + 72f;
        StartCoroutine(RotateWheel(currentAngle, targetAngle));
    }

    public bool GetCanInteract()
    {
        return interacting;
    }

    private IEnumerator RotateWheel(float currentAngle, float targetAngle)
    {
        while(currentAngle != targetAngle)
        {
            wheelLock.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
            currentAngle += (rotationSpeed * Time.deltaTime);
            if(currentAngle > targetAngle - 2 && currentAngle < targetAngle + 2)
            {
                currentAngle = targetAngle;
                interacting = true;
                Quaternion temp = Quaternion.Euler(targetAngle, 0f, 90f);
                wheelLock.localRotation = temp;
                tempRotation = targetAngle;
            }
            yield return null;
        }
    }
}
