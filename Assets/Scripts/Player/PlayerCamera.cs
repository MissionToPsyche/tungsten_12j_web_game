using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform cameraFollowTarget;

    private PlayerInput input;

    private float xRotation;
    private float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.LookAt(cameraFollowTarget);
    }

    private void LateUpdate()
    {


        //xRotation -= input.look.y * .5f;
        //yRotation -= input.look.x * .5f;
        Quaternion rotation = Quaternion.Euler(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, 0f);
        cameraFollowTarget.rotation = rotation;
    }
}
