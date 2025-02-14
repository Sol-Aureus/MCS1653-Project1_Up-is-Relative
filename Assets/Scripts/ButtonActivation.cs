using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private PlatformMovement platformMovement;

    // Start is called before the first frame update
    void Start()
    {
        platformMovement = platform.GetComponent<PlatformMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // When the player enters the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            platformMovement.ToggleMove();
            gameObject.SetActive(false);
        }
    }
}
