using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    public string sahneAdi;
    public GameObject FadeScreen;

    public void OyunaBasla()
    {
        SceneManager.LoadScene(sahneAdi);

    }

    public void OyuncadanCýkýs()
    {
        Application.Quit();

    }

    





}
