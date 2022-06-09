using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EziciKutuController : MonoBehaviour
{

    [SerializeField]
    GameObject yokOlmaEfekti;
    PlayerController playerController;
    public float kirazinCýkmaSansi;
    public GameObject kirazObje;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Kurbaga"))
        {
            Other.transform.parent.gameObject.SetActive(false);
            Instantiate(yokOlmaEfekti, transform.position, transform.rotation);

            playerController.ZýplaZýplaFNC();

            float cikmaAralýgý = Random.Range(0f, 100f);

            SesController.Ýnstance.SesEfektiCikar(0);

            if (cikmaAralýgý<= kirazinCýkmaSansi)
            {
                Instantiate(kirazObje, Other.transform.position, Other.transform.rotation); 
            }

        }
    }
}
