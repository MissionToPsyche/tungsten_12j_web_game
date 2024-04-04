using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player3DMovement : MonoBehaviour
{
    private PlayerInput input;
    private PlayerAnimator anim;
    private SurfaceCollision sc;

    private PlayerSFX pSFX;
    private bool isWalking = false;

    private CharacterController playerController;
    [SerializeField]
    private Transform mainCam;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float turnSpeed = 20f;

    private float gravity = 9.8f;

    [SerializeField]
    private float jumpSpeed = 10f;
    private bool jumpPressed = false;
    [SerializeField]
    private float jumpHeight = 10f;

    private bool isGrounded = true;

    [SerializeField]
    private float rayCastDistance;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheckHolder;
    private float groundTimer;

    private Vector3 playerJumpVelocity;

    public RaycastHit hit;

    Vector3 playerInput;
    Vector3 targetDirection;
    Vector3 movement;


    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        anim = GetComponent<PlayerAnimator>();
        playerController = GetComponent<CharacterController>();
        pSFX = GetComponent<PlayerSFX>();
        isGrounded = true;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Opening the Pause Menu


        Vector3 groundNormal;
        isGrounded = CheckGround(out groundNormal);
        //Debug.Log(isGrounded);
        playerJumpVelocity.y += -gravity * Time.deltaTime;
        if (isGrounded && playerJumpVelocity.y <= 0f)
        {
            anim.isGrounded = true;
            playerJumpVelocity.y = -2f;
            //pSFX.stopStep();

        }
        else
        {
            anim.isGrounded = false;
        }

        playerInput = new Vector3(input.move.x, 0f, input.move.y);
        Quaternion camRotation = Quaternion.Euler(0f, mainCam.eulerAngles.y, 0f);
        Quaternion targetRotation;
        targetDirection = Vector3.zero;

        if (input.move != Vector2.zero)
        {
            targetRotation = Quaternion.LookRotation(playerInput) * camRotation;
            targetDirection = targetRotation * Vector3.forward;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            /*    //play walking audio if grounded
                if (isGrounded && !isWalking)
                {
                    isWalking = true;
                    pSFX.playStep();
                }*/
        }
        else
        {
            /*//player stops walking
            if (isGrounded)
            {
                isWalking = false;
                pSFX.stopStep();
            }*/
        }

        movement = targetDirection * speed * playerInput.magnitude;

        if (jumpPressed && isGrounded)
        {
            float foo = Mathf.Sqrt(jumpHeight * gravity);
            playerJumpVelocity.y = foo;

            isWalking = false;

            //Debug.Log("Walking: " + isWalking);

            //Play jump audio
            pSFX.playJump();

        }

        playerController.Move(movement * Time.deltaTime);
        playerController.Move(playerJumpVelocity * jumpSpeed * Time.deltaTime);

    }

    private void LateUpdate()
    {
        jumpPressed = false;
    }


    private bool CheckGround(out Vector3 normal)
    {
        normal = Vector3.down;
        Vector3 origin = playerController.bounds.center;
        float distance = playerController.bounds.extents.y;
        Vector3 direction = Vector3.down;

        bool ground = Physics.Raycast(origin, direction, out hit, distance + rayCastDistance, groundLayer);

        if (hit.collider != null)
        {
            normal = hit.normal;
        }

        //Debug.Log(ground);

        return ground;
    }

    void OnJump(InputValue value)
    {
        if(isGrounded)
        {
            jumpPressed = value.isPressed;
        }
    }

}
