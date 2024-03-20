using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    [SerializeField]
    private Transform player; // Reference to the player object
    [SerializeField]
    private float smoothSpeed = 0.5f; // Speed of following

    private Vector3 offset; // Offset between object and player

    void Start()
    {
        // Calculate the initial offset between object and player
        offset = transform.position - player.position;
    }

    void Update()
    {
        // Calculate the target position by adding the offset to the player's position
        Vector3 targetPosition = player.position + offset;

        // Smoothly interpolate towards the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Update the position of the object
        transform.position = smoothedPosition;
    }
}
