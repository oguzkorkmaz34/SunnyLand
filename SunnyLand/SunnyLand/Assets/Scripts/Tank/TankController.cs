using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public enum tankDurumlari {atesEtme,darbeAlma,hareketEtme,sonaErdi};
    public tankDurumlari gecerliDurum;
    
    
    [SerializeField]
    Transform tankObje;
    public Animator anim;

    [Header("Hareket")]
    public float hareketHizi;
    public Transform solHedef, sagHedef;
    bool yonuSagmi;
    public GameObject mayinObje;
    public Transform mayinMerkezNoktasi;
    public float mayimBirakmaSuresi;
    float mayinB�rakmaSayac;


    [Header("Ate� Etme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiAtmaSayac;


    [Header("Darbe")]
    public float darbeSuresi;
    float darbeSayac;

    [Header("CanDurumu")]
    public int canDurumu = 5;
    public GameObject tankPatlamaEfekti;
    bool yenildimi;
    public float mermSuresiArt�r, mayinBirakmaSuresiArtir;

    public GameObject tankEziciKutu;

    private void Start()
    {
        gecerliDurum = tankDurumlari.atesEtme;
    }

    private void Update()
    {
        switch (gecerliDurum)
        {
            case tankDurumlari.atesEtme:
                //Ate� edildi�inde oalcak durumlar

                mermiAtmaSayac -= Time.deltaTime;

                if (mermiAtmaSayac<=0)
                {
                    mermiAtmaSayac = mermiAtmaSuresi;
                    var yeniMermi = Instantiate(mermi, mermiMerkezi.position, mermiMerkezi.rotation);
                    yeniMermi.transform.localScale = tankObje.localScale;
                }


                break;
            case tankDurumlari.darbeAlma:
                //Tank darne ald���nda olacak durmlar

                if (darbeSayac>0)
                {
                    darbeSayac -= Time.deltaTime;
                    if (darbeSayac<=0)
                    {
                        gecerliDurum = tankDurumlari.hareketEtme;
                        mayinB�rakmaSayac = 0;

                        if (yenildimi)
                        {
                            tankObje.gameObject.SetActive(false);
                            Instantiate(tankPatlamaEfekti, transform.position, transform.rotation);

                            gecerliDurum = tankDurumlari.sonaErdi; 
                        }
                    }
                }
                break;
            case tankDurumlari.hareketEtme:
                //Tank haretetti�inde olacak durumlar

                if (yonuSagmi)
                {
                    tankObje.position += new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);
                    
                    if (tankObje.position.x>sagHedef.position.x)
                    {
                        tankObje.localScale = Vector3.one;
                        yonuSagmi = false;

                        HareketiDurdurFNC();
                    }
                }
                else
                {
                    tankObje.position -= new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);
                    
                    if (tankObje.position.x < solHedef.position.x)
                    {
                        tankObje.localScale = new Vector3(-1, 1, 1);
                        yonuSagmi = true;

                        HareketiDurdurFNC();
                    }

                }
                mayinB�rakmaSayac -= Time.deltaTime;
                if (mayinB�rakmaSayac<=0)
                {
                    mayinB�rakmaSayac = mayimBirakmaSuresi;
                    Instantiate(mayinObje, mayinMerkezNoktasi.position, mayinMerkezNoktasi.rotation);
                }

                
                
                break;


           
                
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            darbeAlFNC(); 

        }
    }

    public void darbeAlFNC()
    {
        
        gecerliDurum = tankDurumlari.darbeAlma;
        darbeSayac = darbeSuresi;

        anim.SetTrigger("Vur");

        May�nController[] mayinlar = FindObjectsOfType<May�nController>();

        if (mayinlar.Length > 0)
        {
            foreach (May�nController bulunanMayin in mayinlar)
            {
               
               bulunanMayin.patlamaFNC();
            }
        }
        canDurumu--;
        if (canDurumu<=0)
        {
            yenildimi = true;
        }
        else
        {
            mermiAtmaSuresi /= mermSuresiArt�r;
            mayimBirakmaSuresi /= mayinBirakmaSuresiArtir;
        }


    }

    public void HareketiDurdurFNC()
    {
        tankEziciKutu.SetActive(true);
        
        gecerliDurum = tankDurumlari.atesEtme;
        mermiAtmaSayac = mermiAtmaSuresi;
        anim.SetTrigger("HareketiDurdur");

    }



}
