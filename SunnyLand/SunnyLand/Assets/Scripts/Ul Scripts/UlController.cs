using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UlController : MonoBehaviour
{
    [SerializeField]
    Image kalp1_�mg, kalp2_�mg, kalp3_�mg;

    [SerializeField]
    Sprite doluKalp,yarimKalp, bo�Kalp;

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
                kalp1_�mg.sprite = doluKalp;
                kalp2_�mg.sprite = doluKalp;
                kalp3_�mg.sprite = doluKalp;
                break;

            case 5:
                kalp1_�mg.sprite = doluKalp;
                kalp2_�mg.sprite = doluKalp;
                kalp3_�mg.sprite = yarimKalp;
                break;

            case 4:
                kalp1_�mg.sprite = doluKalp;
                kalp2_�mg.sprite = doluKalp;
                kalp3_�mg.sprite = bo�Kalp;
                break;
            case 3:
                kalp1_�mg.sprite = doluKalp;
                kalp2_�mg.sprite = yarimKalp;
                kalp3_�mg.sprite = bo�Kalp;
                break;

            case 2:
                kalp1_�mg.sprite = doluKalp;
                kalp2_�mg.sprite = bo�Kalp;
                kalp3_�mg.sprite = bo�Kalp;
                break;

            case 1:
                kalp1_�mg.sprite = yarimKalp;
                kalp2_�mg.sprite = bo�Kalp;
                kalp3_�mg.sprite = bo�Kalp;
                break;

            case 0:
                kalp1_�mg.sprite = bo�Kalp;
                kalp2_�mg.sprite = bo�Kalp;
                kalp3_�mg.sprite = bo�Kalp;
                break;

        }



    }

    public void MucevhersayisiniGuncelle() 
    {
        mucevherTxt.text=levelManager.toplananM�cevherSayisi.ToString();    
    
    
    }

}
