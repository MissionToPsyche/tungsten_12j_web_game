using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 move;
    public Vector2 look;
    private bool isStartFrame;

    private void Start()
    {
        isStartFrame = true;
    }

    void OnMove(InputValue value)
    {
        if (isStartFrame)
        {
            isStartFrame = false;
            move = Vector2.zero;
        }
        else
        {
            move = value.Get<Vector2>();
        }
    }

    void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }
}
