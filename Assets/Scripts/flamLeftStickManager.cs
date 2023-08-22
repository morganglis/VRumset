using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;
using UltimateXR.Devices;

public class flamLeftStickManager : MonoBehaviour
{
    public AudioClip input;
    public AudioSource Snare;

    public AudioClip input2;
    public AudioSource HiHat;

    public AudioClip input3;
    public AudioSource Crash1;

    public AudioClip input4;
    public AudioSource Crash2;

    public AudioClip input5;
    public AudioSource Tom1;

    public AudioClip input6;
    public AudioSource Tom2;

    public AudioClip input7;
    public AudioSource Floor;

    public AudioClip input9;
    public AudioSource HiHatClosed;

    private float soundStart = 0f;
    private float soundCooldown = 0.4f;

    public Animation crashAnimation;
    public Animation rideAnimation;

    public GameObject rightRingModel;
    public GameObject leftRingModel;

    public float total = 0;
    public float correct = 0;

    public bool isPressed;

    public GameObject rightRingPointCollider;

    public GameObject leftRingPointCollider;

    public GameObject timerObject;
    private flamTimerScript timerscriptManager;

    void Start() 
    {
        timerscriptManager = timerObject.GetComponent<flamTimerScript>();
    }

    void Update() 
    {
        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger)) {
            isPressed = true;
        }

        else if (!(UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger))) {
            isPressed = false;
        }
    }

    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "Snare" && Time.time > soundStart + soundCooldown) 
        {
            Snare.PlayOneShot(input);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "HiHat" && Time.time > soundStart + soundCooldown && !(isPressed)) 
        {
            HiHat.PlayOneShot(input2);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "HiHat" && Time.time > soundStart + soundCooldown && isPressed) 
        {
            HiHatClosed.PlayOneShot(input9);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Crash1" && Time.time > soundStart + soundCooldown) 
        {
            Crash1.PlayOneShot(input3);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
            crashAnimation.Play();
        }

        if (col.gameObject.tag == "Crash2" && Time.time > soundStart + soundCooldown) 
        {
            Crash2.PlayOneShot(input4);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
            rideAnimation.Play();
        }

        if (col.gameObject.tag == "Floor" && Time.time > soundStart + soundCooldown) 
        {
            Floor.PlayOneShot(input7);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Tom1" && Time.time > soundStart + soundCooldown) 
        {
            Tom1.PlayOneShot(input5);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Tom2" && Time.time > soundStart + soundCooldown) 
        {
            Tom2.PlayOneShot(input6);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }
        
        if (col.gameObject.tag == "leftRing") 
        {
            leftRingModel.SetActive(false);
            rightRingModel.SetActive(true);
            StartCoroutine(lefthitCoolDown());
        }

        if (col.gameObject.tag == "rightRing") 
        {
            StartCoroutine(lefthitCoolDown());
        }

        if(col.gameObject.tag == "leftRingPointCollider") 
        {
            leftRingPointCollider.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "rightRingPointCollider") 
        {
            rightRingPointCollider.SetActive(false);
            total += 1;
        }
    }

    IEnumerator lefthitCoolDown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        rightRingPointCollider.SetActive(true);
    }
}
