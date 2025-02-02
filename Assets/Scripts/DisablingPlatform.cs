using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablingPlatform : MonoBehaviour
{
    // Sets the platform to be disabled
    public void DisablePlatform()
    {
        gameObject.SetActive(false);
    }

    // Sets the platform to be enabled
    public void EnablePlatform()
    {
        gameObject.SetActive(true);
    }
}
