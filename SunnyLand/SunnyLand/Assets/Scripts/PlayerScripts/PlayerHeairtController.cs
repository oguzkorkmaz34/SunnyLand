using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeairtController : MonoBehaviour
{
    public int maxSaglik, gecerliSaglik;

    public float yenilmezklikSuresi;
    float yenilmezlikSayaci;
    [SerializeField]
    GameObject yokOlmaEfekti;
    UlController ulController;
    SpriteRenderer sr;

    PlayerController playerController;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        sr = GetComponent<SpriteRenderer>(); 
        ulController = Object.FindObjectOfType<UlController>();
    }

    private void Start()
    {
        gecerliSaglik = maxSaglik;
    }

    private void Update()
    {
        yenilmezlikSayaci -= Time.deltaTime;
        if (yenilmezlikSayaci<=0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }

    public void hasarAl()
    {
        if (yenilmezlikSayaci <= 0)
        {
            gecerliSaglik--;
            if (gecerliSaglik <= 0)
            {
                gecerliSaglik = 0;
                gameObject.SetActive(false);
               Instantiate(yokOlmaEfekti,transform.position,transform.rotation);
                SesController.Ýnstance.SesEfektiCikar(2);
            }
            else
            {
                yenilmezlikSayaci = yenilmezklikSuresi;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                playerController.GeritepmeFNC();
                SesController.Ýnstance.SesEfektiCikar(1);
            }
          
             ulController.SaglikDurumGuncelle();

        }


    }


    public void caniArttirFNC()
    {
        gecerliSaglik++;
        if (gecerliSaglik >= maxSaglik) 
        {
            gecerliSaglik = maxSaglik;
        }
      
        ulController.SaglikDurumGuncelle();
    }
}
