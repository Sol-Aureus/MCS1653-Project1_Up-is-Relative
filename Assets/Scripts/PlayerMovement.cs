using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Connecting player obejct
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSprite;

    // Left right movement
    public float moveSpeed;
    public float totalFlipTimes;
    private float flipTimes;
    private float playerInput;
    public float jumpPower;

    // Ground check
    private CapsuleCollider2D groundCollider;
    public bool isFlipped;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        groundCollider = GetComponent<CapsuleCollider2D>();
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

        // Resets the flip times if the player is grounded
        if (IsGrounded())
        {
            ResetFlips();
        }

        // Flips the player gravity if they are grounded or have flips left
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            FlipGravity();
            ResetFlips();
        }
        else if (Input.GetButtonDown("Jump") && !IsGrounded() && flipTimes > 0)
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

    bool IsGrounded()
    {
        return groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    // Resets the flip times
    public void ResetFlips()
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
    public void FlipGravity()
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
