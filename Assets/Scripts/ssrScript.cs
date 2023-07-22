using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR;
using TMPro;

public class ssrScript : MonoBehaviour {
    
    public GameObject hihat;
    public GameObject menuTitleUI;
    public GameObject startButtonUI;
    public GameObject tutorialButtonUI;
    public GameObject lobbyButtonUI;
    public GameObject sSRTutorialTitleUI;
    public GameObject backButtonUI;
    public GameObject ssRInProgressUI;
    public GameObject timeLeftTextUI;
    public GameObject rudimentCompleteUI;
    public GameObject timeLeftDisplayText;
    public GameObject accuracyTitle;
    public GameObject accuracyDisplayText;

    public GameObject rightStick;
    private RightStickManager RscriptManager;

    public GameObject leftStick;
    private LeftStickManager LscriptManager;

    public GameObject timerObject;
    private TimerScript timerscriptManager;

    public AudioClip input1;
    public AudioSource Kick;

    public AudioClip input2;
    public AudioSource hihatCloseInput;

    public Animation kickAnimation;

    public bool isPressed;
    private bool pressed = false;
    public bool startButton = false;
    private float soundStart = 0f;
    private float soundCooldown = 0.4f;
    public float finaltotal;
    public float finalcorrect;
    public float accuracy;

    public TextMeshProUGUI accuracyText;

    void Start() 
    {
        RscriptManager = rightStick.GetComponent<RightStickManager>();
        LscriptManager = leftStick.GetComponent<LeftStickManager>();
        timerscriptManager = timerObject.GetComponent<TimerScript>();
        accuracy = 0;
    }

    void Update()
    {
        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Trigger) && Time.time > soundStart + soundCooldown) 
        {
            kickAnimation.Play();
            Kick.pitch = Random.Range(0.8f, 1.2f);
            Kick.PlayOneShot(input1);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Left, UxrInputButtons.Trigger) && Time.time > soundStart + soundCooldown) 
        {
            hihatCloseInput.PlayOneShot(input2);
            soundStart = Time.time;
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger)) 
        {
            isPressed = true;        
        }

        else if (!(UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger))) 
        {
            isPressed = false;
        }

        if (isPressed) {
            hihat.transform.position = new Vector3(2.4866f, 93.6796f, -0.8179f);
        }

        else if (!isPressed) {
            hihat.transform.position = new Vector3(2.486763f, 93.70355f, -0.8180155f);
        }

        if (timerscriptManager.timeRemaining == 0) 
        {
            ssRInProgressUI.SetActive(false);
            timeLeftTextUI.SetActive(false);
            timeLeftDisplayText.SetActive(false);
            rudimentCompleteUI.SetActive(true);
            backButtonUI.SetActive(true);
            accuracyTitle.SetActive(true);
            accuracyDisplayText.SetActive(true);
        }

        finaltotal = RscriptManager.total + LscriptManager.total;
        finalcorrect = RscriptManager.correct + LscriptManager.correct;
        accuracy = (finalcorrect / finaltotal) * 100;
        accuracyText.text = string.Format("{0:00}{1}", accuracy, "%");
    }

    public void startButtonFunc()
    {
        if (pressed)
        {
            return;
        }

        startButton = true;
        pressed = true;
        StartCoroutine(PressCooldown());

        menuTitleUI.SetActive(false);
        startButtonUI.SetActive(false);
        tutorialButtonUI.SetActive(false);
        lobbyButtonUI.SetActive(false);
        sSRTutorialTitleUI.SetActive(false);
        backButtonUI.SetActive(false);
        ssRInProgressUI.SetActive(true);
        timeLeftTextUI.SetActive(true);
        timeLeftDisplayText.SetActive(true);
    }

    public void tutorialButtonFunc()
    {
        if (pressed)
        {
            return;
        }

        pressed = true;
        StartCoroutine(PressCooldown());

        menuTitleUI.SetActive(false);
        tutorialButtonUI.SetActive(false);
        lobbyButtonUI.SetActive(false);
        sSRTutorialTitleUI.SetActive(true);
        backButtonUI.SetActive(true);
        ssRInProgressUI.SetActive(false);
        timeLeftTextUI.SetActive(false);
    }

    public void backButtonFunc()
    {
        if (pressed)
        {
            return;
        }

        pressed = true;
        StartCoroutine(PressCooldown());
        accuracy = 0;
        finalcorrect = 0;
        finaltotal = 0;
        RscriptManager.total = 0;
        RscriptManager.correct = 0;
        LscriptManager.total = 0;
        LscriptManager.correct = 0;
        timerscriptManager.timeRemaining = 60;
        menuTitleUI.SetActive(true);
        tutorialButtonUI.SetActive(true);
        startButtonUI.SetActive(true);
        lobbyButtonUI.SetActive(true);
        sSRTutorialTitleUI.SetActive(false);
        backButtonUI.SetActive(false);
        ssRInProgressUI.SetActive(false);
        timeLeftTextUI.SetActive(false);
        accuracyDisplayText.SetActive(false);
        accuracyTitle.SetActive(false);
        rudimentCompleteUI.SetActive(false);

    }

    IEnumerator PressCooldown()
        {
            yield return new WaitForSecondsRealtime(1.5f);
            pressed = false;
        }
}