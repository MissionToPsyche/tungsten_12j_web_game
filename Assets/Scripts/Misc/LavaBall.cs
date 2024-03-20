using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(speed, 0f, 0f) * Time.deltaTime);

    }

}
