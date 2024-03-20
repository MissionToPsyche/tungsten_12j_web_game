using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaLiftMovement : MonoBehaviour
{

    [SerializeField]
    private float minimumHeight;

    [SerializeField]
    private float maximumHeight;
    public float speed;

    [SerializeField]
    private float pausePeriod;

    private float _frame = 0f;
    private bool isMovingUp = true;
    private float offset = 1.2f;

    public Vector3 movement;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        //Platform rises and falls on a timed interval

        //Waits a certain amount of frames before moving again
        if (_frame <= pausePeriod) {
            _frame += 1f;
            movement = Vector2.zero;
        }
        else
        {
            //Change behavior depending on position of the platform
            if (transform.position.y >= maximumHeight + offset)
            {
               // transform.position = new Vector3(transform.position.x, maximumHeight + offset, transform.position.z);
                isMovingUp = false;
                _frame = 0;
            }
            else if (transform.position.y <= minimumHeight + offset) 
            {
                //transform.position = new Vector3(transform.position.x, minimumHeight + offset, transform.position.z);
                isMovingUp = true;
                _frame = 0;
            }

            if (isMovingUp)
            {
                movement = new Vector3(0, speed, 0);
            }
            else
            {
                movement = new Vector3(0, -speed, 0);
            }

            movement.Normalize();
        }

        rb.velocity = movement * speed;

    }
}
