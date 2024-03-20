using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator anim;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();  
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            anim.SetFloat("Move", playerInput.move.magnitude);
        }
        else
        {
            anim.SetFloat("Move", 0f);
        }
        anim.SetBool("Grounded", isGrounded);
    }
}
