using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class menuScript : MonoBehaviour
{

    public GameObject rudimentButton;
    public GameObject tutorialButton;
    public GameObject freePlayButton;

    public GameObject ssrButton;
    public GameObject dsrButton;
    public GameObject fButton;
    public GameObject pButton;
    public GameObject dpButton;

    public GameObject welcomeBanner;
    public GameObject tutorialBanner;
    public GameObject rudimentBanner;
    public GameObject confirmBanner;


    public GameObject ssrConfirmButton;
    public GameObject dsrConfirmButton;
    public GameObject fConfirmButton;
    public GameObject pConfirmButton;
    public GameObject dpConfirmButton;
    public GameObject freePlayConfirmButton;

    public GameObject backButton;

    public GameObject tutorialVid;
    public GameObject videoPlayer;
    

    private bool pressed = false;

    public void tutorialButtonFunc()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        tutorialBanner.SetActive(true);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
        backButton.SetActive(true);
        tutorialVid.SetActive(true);
        videoPlayer.SetActive(true);

    }

    public void rudimentButtonFunc()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        tutorialBanner.SetActive(false);
        rudimentBanner.SetActive(true);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
        ssrButton.SetActive(true);
        dsrButton.SetActive(true);
        fButton.SetActive(true);
        pButton.SetActive(true);
        dpButton.SetActive(true);
        backButton.SetActive(true);
        
    }

    public void freePlayConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        tutorialBanner.SetActive(false);
        confirmBanner.SetActive(true);
        freePlayConfirmButton.SetActive(true);
        backButton.SetActive(true);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
    }

    public void backButtonFunc()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(true);
        rudimentButton.SetActive(true);
        tutorialButton.SetActive(true);
        freePlayButton.SetActive(true);

        backButton.SetActive(false);
        rudimentBanner.SetActive(false);
        ssrButton.SetActive(false);
        dsrButton.SetActive(false);
        fButton.SetActive(false);
        pButton.SetActive(false);
        dpButton.SetActive(false);
        ssrConfirmButton.SetActive(false);
        dsrConfirmButton.SetActive(false);
        fConfirmButton.SetActive(false);
        pConfirmButton.SetActive(false);
        dpConfirmButton.SetActive(false);
        confirmBanner.SetActive(false);

        videoPlayer.SetActive(false);
        rudimentBanner.SetActive(false);
        tutorialBanner.SetActive(false);
        confirmBanner.SetActive(false);

    }

    public void ssrConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        tutorialBanner.SetActive(false);
        confirmBanner.SetActive(true);
        ssrConfirmButton.SetActive(true);
        backButton.SetActive(true);
        rudimentBanner.SetActive(false);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
        ssrButton.SetActive(false);
        dsrButton.SetActive(false);
        fButton.SetActive(false);
        pButton.SetActive(false);
        dpButton.SetActive(false);

    }

    public void dsrConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        tutorialBanner.SetActive(false);
        confirmBanner.SetActive(true);
        dsrConfirmButton.SetActive(true);
        backButton.SetActive(true);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
    }

    public void fConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        tutorialBanner.SetActive(false);
        confirmBanner.SetActive(true);
        fConfirmButton.SetActive(true);
        backButton.SetActive(true);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);

    }

    public void pConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        tutorialBanner.SetActive(false);
        confirmBanner.SetActive(true);
        pConfirmButton.SetActive(true);
        backButton.SetActive(true);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);

    }

    public void dpConfirm()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        tutorialBanner.SetActive(false);
        confirmBanner.SetActive(true);
        dpConfirmButton.SetActive(true);
        backButton.SetActive(true);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);

    }

    IEnumerator PressCooldown()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        pressed = false;
    }
}
