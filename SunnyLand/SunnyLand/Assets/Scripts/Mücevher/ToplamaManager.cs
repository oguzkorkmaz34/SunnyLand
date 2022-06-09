using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
{
    [SerializeField]
    bool mucevhermi,kirazmi;
    bool toplandimi;

    [SerializeField]
    GameObject toplamaEfekti;

    LevelManager levelManager;
    UlController ulController;
    PlayerHeairtController playerHeairtController;

    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        ulController=Object.FindObjectOfType<UlController>();
        playerHeairtController=Object.FindObjectOfType<PlayerHeairtController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !toplandimi)
        {
            if (mucevhermi)
            {
                levelManager.toplananMücevherSayisi++;
                toplandimi = true;
                Destroy(gameObject);

                ulController.MucevhersayisiniGuncelle();
                Instantiate(toplamaEfekti,transform.position,transform.rotation);
                SesController.Ýnstance.SesEfektiCikar(7);
            }
           
            if (kirazmi)
            {
                if (playerHeairtController.gecerliSaglik!=playerHeairtController.maxSaglik)
                {
                    playerHeairtController.caniArttirFNC();
                    toplandimi = true;
                    Destroy(gameObject);
                    Instantiate(toplamaEfekti, transform.position, transform.rotation);
                    SesController.Ýnstance.SesEfektiCikar(4);
                }


            }
        } 
    }
}
