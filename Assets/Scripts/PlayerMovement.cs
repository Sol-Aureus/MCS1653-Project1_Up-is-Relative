using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Connecting player obejct
    public Rigidbody2D playerRigidbody;
    public SpriteRenderer playerSprite;

    // Left right movement
    public float moveSpeed;
    public float totalFlipTimes;
    private float flipTimes;
    private float playerInput;
    public float jumpPower;

    // Ground check
    public LayerMask groundLayer;
    public Transform bodyPosition;
    public Transform bodyPosition2;
    public float groundCheckRadius;
    private bool isGrounded;
    private bool isGrounded2;
    private bool isFlipped;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Gets the horizontal input
        playerInput = Input.GetAxisRaw("Horizontal");

        // Flips the player sprite based on the input
        if (playerInput > 0)
        {
            playerSprite.flipX = false;
        }
        else if (playerInput < 0)
        {
            playerSprite.flipX = true;
        }

        // Checks if the player is grounded
        isGrounded = Physics2D.OverlapCircle(bodyPosition.position, groundCheckRadius, groundLayer);
        isGrounded2 = Physics2D.OverlapCircle(bodyPosition2.position, groundCheckRadius, groundLayer);

        // Resets the flip times if the player is grounded
        if (isGrounded || isGrounded2)
        {
            ResetFlips();
        }

        // Flips the player gravity if they are grounded or have flips left
        if (Input.GetButtonDown("Jump") && (isGrounded || isGrounded2))
        {
            FlipGravity();
            ResetFlips();
        }
        else if (Input.GetButtonDown("Jump") && !(isGrounded || isGrounded2) && flipTimes > 0)
        {
            FlipGravity();
            flipTimes--;
        }
    }

    // Fixed update is called at a fixed interval
    void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector2(playerInput * moveSpeed, playerRigidbody.velocity.y);
    }

    // Resets the flip times
    void ResetFlips()
    {
        flipTimes = totalFlipTimes;
    }

    // Makes the player "jump"
    void Jump()
    {
        // Adds some velocity to the player
        if (isFlipped)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, (playerRigidbody.velocity.y / 3) - jumpPower);
        }
        else
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, (playerRigidbody.velocity.y / 3) + jumpPower);
        }
    }

    // Reverses the gravity of the player
    void FlipGravity()
    {
        // Flips the gravity
        playerRigidbody.gravityScale *= -1;

        // Flips the sprite
        playerSprite.flipY = !playerSprite.flipY;

        // Adds some velocity to the player
        Jump();

        // Flips the boolean
        isFlipped = !isFlipped;
    }
}
