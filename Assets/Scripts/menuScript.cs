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
    public GameObject rudimentBanner;
    public GameObject confirmBanner;

    public GameObject freePlayConfirmButton;

    public GameObject backButton;

    public GameObject tutorialVid;
    public GameObject videoPlayer;

    public VideoPlayer tutorialVideo;

    public GameObject pauseButtonUI;
    public GameObject playButtonUI;

    private bool pressed = false;

    BoxCollider ssrCollider;
    BoxCollider paraCollider;
    BoxCollider doubparaCollider;
    BoxCollider dsrCollider;
    BoxCollider flamCollider;

    void Start() 
    { 
        ssrCollider = ssrButton.GetComponent<BoxCollider>();
        paraCollider = pButton.GetComponent<BoxCollider>();
        doubparaCollider = dpButton.GetComponent<BoxCollider>();
        dsrCollider = dsrButton.GetComponent<BoxCollider>();
        flamCollider = fButton.GetComponent<BoxCollider>();

        ssrCollider.enabled = false;
        paraCollider.enabled = false;
        doubparaCollider.enabled = false;
        dsrCollider.enabled = false;
        flamCollider.enabled = false;
    }

    public void tutorialButtonFunc()
    {
        if (pressed)
        {
            return;
        }
        
        pressed = true;
        StartCoroutine(PressCooldown());

        welcomeBanner.SetActive(false);
        rudimentButton.SetActive(false);
        tutorialButton.SetActive(false);
        freePlayButton.SetActive(false);
        backButton.SetActive(true);
        tutorialVid.SetActive(true);
        videoPlayer.SetActive(true);
        pauseButtonUI.SetActive(true);

    }

    public void rudimentButtonFunc()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());
        StartCoroutine(ColliderCooldown());
        welcomeBanner.SetActive(false);
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
        confirmBanner.SetActive(false);
        freePlayConfirmButton.SetActive(false);

        videoPlayer.SetActive(false);
        tutorialVid.SetActive(false);
        rudimentBanner.SetActive(false);
        confirmBanner.SetActive(false);

        playButtonUI.SetActive(false);
        pauseButtonUI.SetActive(false);

    }

    public void pauseButton()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());
        tutorialVideo.Pause();
        pauseButtonUI.SetActive(false);
        playButtonUI.SetActive(true);
    }

    public void playButton()
    {
        if (pressed)
        {
            return;
        }
        pressed = true;
        StartCoroutine(PressCooldown());
        tutorialVideo.Play();
        playButtonUI.SetActive(false);
        pauseButtonUI.SetActive(true);
    }

    IEnumerator PressCooldown()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        pressed = false;
    }

    IEnumerator ColliderCooldown() // UI button cooldown function so the user can't accidentally hit a button when it loads in too quick
    {
        yield return new WaitForSecondsRealtime(1.5f);
        ssrCollider.enabled = true;
        paraCollider.enabled = true;
        doubparaCollider.enabled = true;
        dsrCollider.enabled = true;
        flamCollider.enabled = true;

    }
}
