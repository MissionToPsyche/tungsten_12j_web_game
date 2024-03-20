using UnityEngine;
using System.Collections;
using System.Net.Http.Headers;

namespace AstronautPlayer
{

    public class AstronautPlayer : MonoBehaviour
    {

        private Animator anim;
        private CharacterController controller;

        public float speed = 600.0f;
        public float turnSpeed = 400.0f;
        private Vector3 moveDirection = Vector3.zero;
        public float gravity = 40.0f;
        [SerializeField]
        private float jumpSpeed = 10.0f;
        [SerializeField]
        private LayerMask groundLayers;
        [SerializeField]
        private float rayDistance = 2f;

        private bool isGrounded;
        private bool hasJumped;
        private RaycastHit hit;

        [SerializeField] 
        private Transform camera;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, rayDistance, groundLayers);
            hasJumped = Input.GetButtonDown("Jump");

            Vector3 forward = camera.forward;
            Vector3 right = camera.right;
            forward.y = 0;
            right.y = 0;

            if (isGrounded)
            {
                anim.SetBool("JumpAnimation", false);

                moveDirection = (Input.GetAxis("Vertical") * speed * forward) + (Input.GetAxis("Horizontal") * speed * right);
                RunAnimation();
                JumpCheck();
            }
            else
            {
                anim.SetBool("JumpAnimation", true);
            }

            if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                Quaternion temp = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
                temp.x = 0;
                temp.z = 0;
                transform.localRotation = temp;
            }

            PlayerMove();
        }

        private void RunAnimation()
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                anim.SetInteger("AnimationPar", 1);
            }
            else
            {
                anim.SetInteger("AnimationPar", 0);
            }
        }

        private void JumpCheck()
        {
            if(hasJumped)
            {
                hasJumped = false;
                moveDirection.y = jumpSpeed;
                controller.Move(moveDirection * Time.deltaTime);
            }
        }

        private void PlayerMove()
        {
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(Vector3.ProjectOnPlane(moveDirection * Time.deltaTime, hit.normal));
        }
    }
}
