using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SesController : MonoBehaviour
{
    public static SesController Ưnstance;

    public AudioSource[] sesefektleri;

    private void Awake()
    {
        Ưnstance = this;
        
    }

    public void SesEfektiCikar(int hangiSes)
    {

        sesefektleri[hangiSes].Stop(); 
        sesefektleri[hangiSes].Play(); 
    }

}






