using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Variables
    private RespawnPlayer respawn;
    private BoxCollider2D checkPointCollider;
    private GameObject[] lava;

    // Start is called before the first frame update
    void Start()
    {
        lava = GameObject.FindGameObjectsWithTag("Respawn"); // Returns an array of GameObjects with the tag "Respawn"
        checkPointCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject script in lava) // Cycle through all the lava objects
            {
                if (script.GetComponent<RespawnPlayer>() != null) // Checks if the "RespawnPlayer" script is attached to the lava object
                {
                    respawn = script.GetComponent<RespawnPlayer>(); // Connect to the "RespawnPlayer" script

                    respawn.respawnPoint = this.gameObject; // Set the respawn point to this checkpoint
                }
            }

            // Disable the collider so the player can't set the respawn point again
            checkPointCollider.enabled = false;
        }
    }
}
