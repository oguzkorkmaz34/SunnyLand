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
    float mayinBırakmaSayac;


    [Header("Ateş Etme")]
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
    public float mermSuresiArtır, mayinBirakmaSuresiArtir;

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
                //Ateş edildiğinde oalcak durumlar

                mermiAtmaSayac -= Time.deltaTime;

                if (mermiAtmaSayac<=0)
                {
                    mermiAtmaSayac = mermiAtmaSuresi;
                    var yeniMermi = Instantiate(mermi, mermiMerkezi.position, mermiMerkezi.rotation);
                    yeniMermi.transform.localScale = tankObje.localScale;
                }


                break;
            case tankDurumlari.darbeAlma:
                //Tank darne aldığında olacak durmlar

                if (darbeSayac>0)
                {
                    darbeSayac -= Time.deltaTime;
                    if (darbeSayac<=0)
                    {
                        gecerliDurum = tankDurumlari.hareketEtme;
                        mayinBırakmaSayac = 0;

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
                //Tank haretettiğinde olacak durumlar

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
                mayinBırakmaSayac -= Time.deltaTime;
                if (mayinBırakmaSayac<=0)
                {
                    mayinBırakmaSayac = mayimBirakmaSuresi;
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

        MayınController[] mayinlar = FindObjectsOfType<MayınController>();

        if (mayinlar.Length > 0)
        {
            foreach (MayınController bulunanMayin in mayinlar)
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
            mermiAtmaSuresi /= mermSuresiArtır;
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
