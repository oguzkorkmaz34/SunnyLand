using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EziciKutuController : MonoBehaviour
{

    [SerializeField]
    GameObject yokOlmaEfekti;
    PlayerController playerController;
    public float kirazinC�kmaSansi;
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

            playerController.Z�plaZ�plaFNC();

            float cikmaAral�g� = Random.Range(0f, 100f);

            SesController.�nstance.SesEfektiCikar(0);

            if (cikmaAral�g�<= kirazinC�kmaSansi)
            {
                Instantiate(kirazObje, Other.transform.position, Other.transform.rotation); 
            }

        }
    }
}
