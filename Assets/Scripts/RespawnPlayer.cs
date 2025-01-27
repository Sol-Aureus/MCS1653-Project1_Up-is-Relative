using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    // Connect to RespawnPlayer
    public GameObject player;
    public GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something has entered the trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger");
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
