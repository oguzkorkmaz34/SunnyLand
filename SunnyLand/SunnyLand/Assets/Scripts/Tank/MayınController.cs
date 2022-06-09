using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayınController : MonoBehaviour
{
    public GameObject patlamaEfekti;
    PlayerHeairtController playerHeairtController;

    private void Awake()
    {
        playerHeairtController = Object.FindObjectOfType<PlayerHeairtController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            patlamaFNC();  
            playerHeairtController.hasarAl();
        }
    }

    public void patlamaFNC()
    {
        Destroy(this.gameObject);

        Instantiate(patlamaEfekti, transform.position, transform.rotation);
    }


}

