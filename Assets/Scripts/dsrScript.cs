using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR;
using TMPro;

public class dsrScript : MonoBehaviour {
    
    public GameObject hihat;
    public GameObject menuTitleUI;
    public GameObject startButtonUI;
    public GameObject tutorialButtonUI;
    public GameObject lobbyButtonUI;
    public GameObject backButtonUI;
    public GameObject dsRInProgressUI;
    public GameObject timeLeftTextUI;
    public GameObject rudimentCompleteUI;
    public GameObject timeLeftDisplayText;
    public GameObject accuracyTitle;
    public GameObject accuracyDisplayText;
    public GameObject lobbyConfirmUI;
    public GameObject lobbyConfirmButtonUI;

    public GameObject rightStick;
    private dsrRightStickManager RscriptManager;

    public GameObject leftStick;
    private dsrLeftStickManager LscriptManager;

    public GameObject timerObject;
    private dsrTimerScript timerscriptManager;

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

    public GameObject tutorialVid;
    public GameObject videoPlayer;

    public TextMeshProUGUI accuracyText;

    void Start() 
    {
        RscriptManager = rightStick.GetComponent<dsrRightStickManager>(); // Grab our right stick script
        LscriptManager = leftStick.GetComponent<dsrLeftStickManager>();    // Grab our left stick script
        timerscriptManager = timerObject.GetComponent<dsrTimerScript>();   // Grab our timer script
        accuracy = 0;   // Ensure accuracy is set to 0
    }

    void Update()
    {
        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Trigger) && Time.time > soundStart + soundCooldown) // Determines if the right trigger is being pressed and ensures a cooldown so that the kick sound/animation does not play nonsense
        {
            kickAnimation.Play();   // Plays our kick animation
            Kick.pitch = Random.Range(0.8f, 1.2f);  // Puts a bit of variety in the pitch of the sound of the kick
            Kick.PlayOneShot(input1);   // Plays the sound of the kick
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); // Sends haptic feedback to our left controller
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Left, UxrInputButtons.Trigger) && Time.time > soundStart + soundCooldown) 
        {
            hihatCloseInput.PlayOneShot(input2);
            soundStart = Time.time;
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger)) // Determines if the left rigger is being pressed
        {
            isPressed = true;        
        }

        else if (!(UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger))) 
        {
            isPressed = false;
        }

        if (isPressed)  // If the right trigger has been pressed it closes the hi hat
        {
            hihat.transform.position = new Vector3(2.4866f, 93.6796f, -0.8179f);    // Puts the top of the hi hat in a new position
        }

        else if (!isPressed) 
        {
            hihat.transform.position = new Vector3(2.486763f, 93.70355f, -0.8180155f);  // If the right trigger is not being pressed then the hi hat stays open
        }

        if (timerscriptManager.timeRemaining == 0)  // If the timeRemaining variable from the timer script is zero, UI accuracy info is displayed
        {
            dsRInProgressUI.SetActive(false);
            timeLeftTextUI.SetActive(false);
            timeLeftDisplayText.SetActive(false);
            rudimentCompleteUI.SetActive(true);
            backButtonUI.SetActive(true);
            accuracyTitle.SetActive(true);
            accuracyDisplayText.SetActive(true);
        }

        finaltotal = RscriptManager.total + LscriptManager.total;   // Calculates our final total from the right and left stick hits
        finalcorrect = RscriptManager.correct + LscriptManager.correct;     // Calculates our final correct total from right and left sticks
        accuracy = (finalcorrect / finaltotal) * 100;   // Divide the correct number of hits by the total number of hits and multiply by 100 to get the accuracy
        accuracyText.text = string.Format("{0:00}{1}", accuracy, "%");  // Format how the accuracy variable should display

    }

    public void startButtonFunc()   // Controls what happens when the start button is pressed
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
        backButtonUI.SetActive(false);
        dsRInProgressUI.SetActive(true);
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
        startButtonUI.SetActive(false);
        tutorialButtonUI.SetActive(false);
        lobbyButtonUI.SetActive(false);
        backButtonUI.SetActive(true);
        dsRInProgressUI.SetActive(false);
        timeLeftTextUI.SetActive(false);
        tutorialVid.SetActive(true);
        videoPlayer.SetActive(true);
    }

    public void lobbyButtonFunc()
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
        startButtonUI.SetActive(false);
        backButtonUI.SetActive(true);
        dsRInProgressUI.SetActive(false);
        timeLeftTextUI.SetActive(false);
        lobbyConfirmButtonUI.SetActive(true);
        lobbyConfirmUI.SetActive(true);
        backButtonUI.SetActive(true);

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
        backButtonUI.SetActive(false);
        dsRInProgressUI.SetActive(false);
        timeLeftTextUI.SetActive(false);
        accuracyDisplayText.SetActive(false);
        accuracyTitle.SetActive(false);
        rudimentCompleteUI.SetActive(false);
        lobbyConfirmButtonUI.SetActive(false);
        lobbyConfirmUI.SetActive(false);
        tutorialVid.SetActive(false);
        videoPlayer.SetActive(false);
    }

    IEnumerator PressCooldown() // UI button cooldown function so the user can't accidentally hit a button when it loads in too quick
    {
        yield return new WaitForSecondsRealtime(1.5f);
        pressed = false;
    }
}