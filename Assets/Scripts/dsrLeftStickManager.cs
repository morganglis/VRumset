using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;
using UltimateXR.Devices;

public class dsrLeftStickManager : MonoBehaviour
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
    public GameObject secondRightRingModel;
    public GameObject leftRingModel;
    public GameObject secondLeftRingModel;

    public float total = 0;
    public float correct = 0;

    public bool isPressed;

    public GameObject rightRingPointCollider;
    public GameObject secondRightRingPointCollider;

    public GameObject leftRingPointCollider;
    public GameObject secondLeftRingPointCollider;

    public GameObject timerObject;
    private dsrTimerScript timerscriptManager;

    void Start() 
    {
        timerscriptManager = timerObject.GetComponent<dsrTimerScript>();
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

            Snare.pitch = Random.Range(1.0f,1.2f);
            Snare.PlayOneShot(input);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "HiHat" && Time.time > soundStart + soundCooldown && !(isPressed)) 
        {
            HiHat.pitch = Random.Range(1.0f,1.2f);
            HiHat.PlayOneShot(input2);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "HiHat" && Time.time > soundStart + soundCooldown && isPressed) 
        {
            HiHatClosed.pitch = Random.Range(1.0f,1.2f);
            HiHatClosed.PlayOneShot(input9);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Crash1" && Time.time > soundStart + soundCooldown) 
        {
            Crash1.pitch = Random.Range(1.0f,1.2f);
            Crash1.PlayOneShot(input3);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
            crashAnimation.Play();
        }

        if (col.gameObject.tag == "Crash2" && Time.time > soundStart + soundCooldown) 
        {
            Crash2.pitch = Random.Range(1.0f,1.2f);
            Crash2.PlayOneShot(input4);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
            rideAnimation.Play();
        }

        if (col.gameObject.tag == "Floor" && Time.time > soundStart + soundCooldown) 
        {
            Floor.pitch = Random.Range(1.0f,1.2f);
            Floor.PlayOneShot(input7);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Tom1" && Time.time > soundStart + soundCooldown) 
        {
            Tom1.pitch = Random.Range(1.0f,1.2f);
            Tom1.PlayOneShot(input5);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Tom2" && Time.time > soundStart + soundCooldown) 
        {
            Tom2.pitch = Random.Range(1.0f,1.2f);
            Tom2.PlayOneShot(input6);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }
        
        if (col.gameObject.tag == "leftRing") 
        {
            leftRingModel.SetActive(false);
            secondLeftRingModel.SetActive(true);
            StartCoroutine(lefthitCoolDown());
        }

        if (col.gameObject.tag == "secondLeftRing")
        {
            secondLeftRingModel.SetActive(false);
            rightRingModel.SetActive(true);
            StartCoroutine(secondlefthitCoolDown());
        }

        if (col.gameObject.tag == "rightRing") 
        {
            StartCoroutine(lefthitCoolDown());
        }

        if (col.gameObject.tag == "secondRightRing") 
        {
            StartCoroutine(secondlefthitCoolDown());
        }

        if(col.gameObject.tag == "leftRingPointCollider") 
        {
            leftRingPointCollider.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "secondleftRingPointCollider") 
        {
            secondLeftRingPointCollider.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "rightRingPointCollider") 
        {
            rightRingPointCollider.SetActive(false);
            total += 1;
        }

        if(col.gameObject.tag == "secondrightRingPointCollider") 
        {
            secondRightRingPointCollider.SetActive(false);
            total += 1;
        }
    }

    IEnumerator lefthitCoolDown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        rightRingPointCollider.SetActive(true);
    }

    IEnumerator secondlefthitCoolDown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        secondRightRingPointCollider.SetActive(true);
    }
}
