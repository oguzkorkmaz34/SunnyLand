using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UlController : MonoBehaviour
{
    [SerializeField]
    Image kalp1_ýmg, kalp2_ýmg, kalp3_ýmg;

    [SerializeField]
    Sprite doluKalp,yarimKalp, boþKalp;

    [SerializeField]
     TMP_Text mucevherTxt;


    PlayerHeairtController playerHeairtController;
    
    LevelManager levelManager;
    private void Awake()
    {
        playerHeairtController = Object.FindObjectOfType<PlayerHeairtController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }

    public void SaglikDurumGuncelle()
    {
        switch (playerHeairtController.gecerliSaglik)
        {
            case 6:
                kalp1_ýmg.sprite = doluKalp;
                kalp2_ýmg.sprite = doluKalp;
                kalp3_ýmg.sprite = doluKalp;
                break;

            case 5:
                kalp1_ýmg.sprite = doluKalp;
                kalp2_ýmg.sprite = doluKalp;
                kalp3_ýmg.sprite = yarimKalp;
                break;

            case 4:
                kalp1_ýmg.sprite = doluKalp;
                kalp2_ýmg.sprite = doluKalp;
                kalp3_ýmg.sprite = boþKalp;
                break;
            case 3:
                kalp1_ýmg.sprite = doluKalp;
                kalp2_ýmg.sprite = yarimKalp;
                kalp3_ýmg.sprite = boþKalp;
                break;

            case 2:
                kalp1_ýmg.sprite = doluKalp;
                kalp2_ýmg.sprite = boþKalp;
                kalp3_ýmg.sprite = boþKalp;
                break;

            case 1:
                kalp1_ýmg.sprite = yarimKalp;
                kalp2_ýmg.sprite = boþKalp;
                kalp3_ýmg.sprite = boþKalp;
                break;

            case 0:
                kalp1_ýmg.sprite = boþKalp;
                kalp2_ýmg.sprite = boþKalp;
                kalp3_ýmg.sprite = boþKalp;
                break;

        }



    }

    public void MucevhersayisiniGuncelle() 
    {
        mucevherTxt.text=levelManager.toplananMücevherSayisi.ToString();    
    
    
    }

}
