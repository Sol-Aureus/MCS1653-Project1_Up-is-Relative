using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    private TogglePlatform platformScript;
    public GameObject platform;
    public bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        platformScript = platform.GetComponent<TogglePlatform>();
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
            if (toggle)
            {
                platformScript.EnablePlatform(); // Disable the platform
            }
            else
            {
                platformScript.DisablePlatform(); // Enable the platform
            }
        }
    }
}
