using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarController : MonoBehaviour
{

    PlayerHeairtController playerHeairtController;

    private void Awake()
    { 
        playerHeairtController = Object.FindObjectOfType<PlayerHeairtController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            playerHeairtController.hasarAl();
        }
    }
}
