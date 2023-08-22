using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;
using UltimateXR.Devices;

public class paraLeftStickManager : MonoBehaviour
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

    public float total = 0;
    public float correct = 0;

    public bool isPressed;

    // I felt it was necessary to shorten the variable names of my rings here since I have so many
    // one-four RR = Right Ring Models
    public GameObject oneRR;
    public GameObject twoRR;
    public GameObject threeRR;
    public GameObject fourRR;
    // one-four LR = Left Ring Models
    public GameObject oneLR;
    public GameObject twoLR;
    public GameObject threeLR;
    public GameObject fourLR;
    // one-four RRPC = Right Ring Point Collider
    public GameObject oneRRPC;
    public GameObject twoRRPC;
    public GameObject threeRRPC;
    public GameObject fourRRPC;
    // one-four LRPC = Left Ring Point Collider
    public GameObject oneLRPC;
    public GameObject twoLRPC;
    public GameObject threeLRPC;
    public GameObject fourLRPC;

    public GameObject timerObject;
    private paraTimerScript timerscriptManager;

    void Start() 
    {
        timerscriptManager = timerObject.GetComponent<paraTimerScript>();
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
        

        if(col.gameObject.tag == "leftRingPointCollider") 
        {
            oneLR.SetActive(false);
            twoRR.SetActive(true);
            StartCoroutine(twoRightHitCooldown());
            oneLRPC.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "secondleftRingPointCollider") 
        {
            twoLR.SetActive(false);
            fourRR.SetActive(true);
            StartCoroutine(fourRightHitCooldown());
            twoLRPC.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "thirdleftRingPointCollider") 
        {
            threeLR.SetActive(false);
            fourLR.SetActive(true);
            StartCoroutine(fourLeftHitCooldown());
            threeLRPC.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "fourthleftRingPointCollider") 
        {
            fourLR.SetActive(false);
            oneRR.SetActive(true);
            StartCoroutine(oneRightHitCooldown());
            fourLRPC.SetActive(false);
            total += 1;
            correct += 1;
        }

        if (col.gameObject.tag == "rightRing") 
        {
            StartCoroutine(oneRightHitCooldown());
        }

        if (col.gameObject.tag == "secondRightRing") 
        {
            StartCoroutine(twoRightHitCooldown());
        }

        if (col.gameObject.tag == "thirdRightRing") 
        {
            StartCoroutine(threeRightHitCooldown());
        }

        if (col.gameObject.tag == "fourthRightRing") 
        {
            StartCoroutine(fourRightHitCooldown());
        }


        if(col.gameObject.tag == "rightRingPointCollider") 
        {
            oneRRPC.SetActive(false);
            total += 1;
        }

        if(col.gameObject.tag == "secondrightRingPointCollider") 
        {
            twoRRPC.SetActive(false);
            total += 1;
        }

        if(col.gameObject.tag == "thirdrightRingPointCollider") 
        {
            threeRRPC.SetActive(false);
            total += 1;
        }

        if(col.gameObject.tag == "fourthrightRingPointCollider") 
        {
            fourRRPC.SetActive(false);
            total += 1;
        }
    }

    IEnumerator fourLeftHitCooldown()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        fourLRPC.SetActive(true);
    }

    IEnumerator oneRightHitCooldown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        oneRRPC.SetActive(true);
    }

    IEnumerator twoRightHitCooldown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        twoRRPC.SetActive(true);
    }

    IEnumerator threeRightHitCooldown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        threeRRPC.SetActive(true);
    }

    IEnumerator fourRightHitCooldown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        fourRRPC.SetActive(true);
    }
}
