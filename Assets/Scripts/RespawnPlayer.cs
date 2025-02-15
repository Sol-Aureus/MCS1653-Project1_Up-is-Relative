using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    // Connect to RespawnPlayer
    private GameObject player;
    private PlayerMovement playerMovement;
    public GameObject respawnPoint;
    private GameObject playerLives;
    private GameObject[] buttons;
    private GameObject[] platforms;
    private GameObject[] lavaPlatforms;
    private ButtonActivation buttonScript;
    private PlatformMovement platformScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPoint = GameObject.FindGameObjectWithTag("CheckPoint");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerLives = GameObject.FindGameObjectWithTag("Lives");
        buttons = GameObject.FindGameObjectsWithTag("Button");
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        lavaPlatforms = GameObject.FindGameObjectsWithTag("Respawn");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetType().ToString().Equals("UnityEngine.CircleCollider2D"))
            {
                player.transform.position = respawnPoint.transform.position;
                if (playerMovement.isFlipped) // If the player is flipped, flip them back
                {
                    playerMovement.FlipGravity();
                }
                playerMovement.ResetFlips();
                playerLives.GetComponent<LivesCounter>().RemoveLife();

                // Resets all buttons
                foreach (GameObject script in buttons) // Cycle through all the button objects
                {
                    if (script.GetComponent<ButtonActivation>() != null) // Checks if the "ButtonActivation" script is attached to the button object
                    {
                        buttonScript = script.GetComponent<ButtonActivation>(); // Connect to the "ButtonActivation" script

                        buttonScript.ResetButton();
                    }
                }

                // Resets all platforms
                foreach (GameObject script in platforms) // Cycle through all the platform objects
                {
                    if (script.GetComponent<PlatformMovement>() != null) // Checks if the "PlatformMovement" script is attached to the button object
                    {
                        platformScript = script.GetComponent<PlatformMovement>(); // Connect to the "PlatformMovement" script

                        platformScript.ResetPlatform();
                    }
                }

                // Resets all platforms
                foreach (GameObject script in lavaPlatforms) // Cycle through all the platform objects
                {
                    if (script.GetComponent<PlatformMovement>() != null) // Checks if the "PlatformMovement" script is attached to the button object
                    {
                        platformScript = script.GetComponent<PlatformMovement>(); // Connect to the "PlatformMovement" script

                        platformScript.ResetPlatform();
                    }
                }
            }
        }
    }
}
