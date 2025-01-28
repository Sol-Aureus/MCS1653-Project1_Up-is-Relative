using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Connecting player object
    private Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the player object
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        // Gets the player's position
        Vector3 desiredPosition = playerTransform.position + offset;

        // Linearly interpolates between the camera's position and the player's position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Sets the camera's x position to the smoothed position
        transform.position = new Vector3(smoothedPosition.x, offset.y, offset.z);
    }
}
