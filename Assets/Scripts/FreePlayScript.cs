using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR;

public class FreePlayScript : MonoBehaviour
{

    public GameObject hihat;

    public AudioClip input8;
    public AudioSource Kick;

    private float soundStart = 0f;
    private float soundCooldown = 0.4f;

    public AudioClip input2;
    public AudioSource hihatCloseInput;

    public Animation kickAnimation;

    public bool isPressed;
    private bool pressed = false;

    public GameObject menuTitleUI;
    public GameObject tutorialButtonUI;
    public GameObject lobbyButtonUI;
    public GameObject backButtonUI;
    public GameObject lobbyConfirmUI;
    public GameObject lobbyConfirmButtonUI;

    void Update()
    {
        
        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Trigger) && Time.time > soundStart + soundCooldown) 
        {

            kickAnimation.Play();
            Kick.pitch = Random.Range(0.8f,1.2f);
            Kick.PlayOneShot(input8);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Left, UxrInputButtons.Trigger) && Time.time > soundStart + soundCooldown) 
        {
            hihatCloseInput.PlayOneShot(input2);
            soundStart = Time.time;
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger)) {
            
            isPressed = true;
        }

        else if (!(UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger))) {
            
            isPressed = false;
        }

        if (isPressed) {
            
            hihat.transform.position = new Vector3(2.4866f, 93.6796f, -0.8179f);
        }

         else if (!isPressed) {

             hihat.transform.position = new Vector3(2.486763f, 93.70355f, -0.8180155f);
         }

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
        menuTitleUI.SetActive(true);
        tutorialButtonUI.SetActive(true);
        lobbyButtonUI.SetActive(true);
        lobbyConfirmButtonUI.SetActive(false);
        lobbyConfirmUI.SetActive(false);

    }

    IEnumerator PressCooldown() // UI button cooldown function so the user can't accidentally hit a button when it loads in too quick
    {
        yield return new WaitForSecondsRealtime(1.5f);
        pressed = false;
    }
        
}

        


