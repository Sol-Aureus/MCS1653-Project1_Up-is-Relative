using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    // Connect to RespawnPlayer
    private GameObject player;
    private PlayerMovement playerMovement;
    public GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPoint = GameObject.FindGameObjectWithTag("CheckPoint");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            if (playerMovement.isFlipped) // If the player is flipped, flip them back
            {
                playerMovement.FlipGravity();
            }
            playerMovement.ResetFlips();
        }
    }
}
