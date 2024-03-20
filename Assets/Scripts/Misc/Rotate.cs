using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]
    private Vector3 rotate;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotate * Time.deltaTime);
    }
}
