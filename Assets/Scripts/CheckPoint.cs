using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Connect to RespawnPlayer
    private RespawnPlayer respawn;
    private BoxCollider2D checkPointCollider;

    // Start is called before the first frame update
    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPlayer>();
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
            // Set the respawn point to this checkpoint
            respawn.respawnPoint = this.gameObject;

            // Disable the collider so the player can't set the respawn point again
            checkPointCollider.enabled = false;
        }
    }
}
