using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SesController : MonoBehaviour
{
    public static SesController Ýnstance;

    public AudioSource[] sesefektleri;

    private void Awake()
    {
        Ýnstance = this;
        
    }

    public void SesEfektiCikar(int hangiSes)
    {

        sesefektleri[hangiSes].Stop(); 
        sesefektleri[hangiSes].Play(); 
    }

}






