using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlatformMovement : MonoBehaviour
{
    // Connect to points
    public Transform[] points;
    public bool move;
    private bool originMove;
    public bool toggle;
    private bool originToggle;

    // Variables
    public int startingPoint;
    public float platformSpeed;
    private float sinTime;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; // Moves the platform to the starting point
        originMove = move;
        originToggle = toggle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            /* Thanks to Rytech for the sine wave function code
             * https://www.youtube.com/watch?v=2Y3Y9-Az7oE
             */
            if (transform.position != points[i].position)
            {
                sinTime += (platformSpeed * Time.deltaTime) / 100; // Gets the move speed of the platform
                sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI); // Keeps the sinTime between 0 and PI
                float t = evaluate(sinTime); // Evaluates the sine wave function
                transform.position = Vector2.Lerp(transform.position, points[i].position, t); // Linearly interpolates between the platform's position and the next point using the sine wave function as the t value
            }

            if (Vector2.Distance(transform.position, points[i].position) < 0.01f)
            {
                if (!toggle)
                {
                    i++;
                }
                else
                {
                    i = 1;
                }
                sinTime = 0;
                if (i >= points.Length)
                {
                    i = 0;
                }
            }
        }
    }

    public float evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f; // Transforms a sine wave function to be from 0 to 1
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform); // Sets the player's parent to the platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); // Removes the player's parent
        }
    }

    public void ToggleMove()
    {
        move = !move;
    }

    // Resets the platform on call
    public void ResetPlatform()
    {
        move = originMove;
        toggle = originToggle;
        transform.position = points[startingPoint].position;
        i = 0;
        sinTime = 0;
    }
}
