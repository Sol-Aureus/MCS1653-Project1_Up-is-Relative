using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Connecting player object
    private Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed;

    // Background images
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;
    [SerializeField] GameObject background3;
    public float background1Speed;
    public float background2Speed;
    public float background3Speed;

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

        // Gets old position
        Vector3 oldPos = transform.position;

        // Sets the camera's x position to the smoothed position
        transform.position = new Vector3(smoothedPosition.x, offset.y, offset.z);

        // Gets new position
        Vector3 newPos = transform.position;

        // Gets the difference between the old and new position
        Vector3 delta = newPos - oldPos;

        // Moves the background images based on the player's movement
        background1.transform.position += new Vector3(delta.x * background1Speed, 0, 0);
        background2.transform.position += new Vector3(delta.x * background2Speed, 0, 0);
        background3.transform.position += new Vector3(delta.x * background3Speed, 0, 0);
    }
}
