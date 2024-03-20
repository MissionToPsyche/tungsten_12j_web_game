using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGear : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = Vector3.zero;
        rotation.z = 1;
        this.transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
