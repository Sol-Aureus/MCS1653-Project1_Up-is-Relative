using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalPoint : MonoBehaviour
{
    // Objects
    [SerializeField] GameObject canvasObject;
    public BoxCollider2D pointCollider;

    // Start is called before the first frame update
    void Start()
    {
        pointCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canvasObject.GetComponent<PauseMenu>().Win(); // If player reaches the object, they win
            pointCollider.enabled = false;
        }
    }
}
