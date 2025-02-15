using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private PlatformMovement platformMovement;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite pressedSprite;

    // Start is called before the first frame update
    void Start()
    {
        platformMovement = platform.GetComponent<PlatformMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // When the player enters the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            platformMovement.ToggleMove();
            circleCollider.enabled = false;
            spriteRenderer.sprite = pressedSprite;
        }
    }

    // Resets the button on call
    public void ResetButton()
    {
        circleCollider.enabled = true;
        spriteRenderer.sprite = normalSprite;
    }
}
