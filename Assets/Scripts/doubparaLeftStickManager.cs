using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;
using UltimateXR.Devices;

public class doubparaLeftStickManager : MonoBehaviour
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
    // one-six RR = Right Ring Models
    public GameObject oneRR;
    public GameObject twoRR;
    public GameObject threeRR;
    public GameObject fourRR;
    public GameObject fiveRR;
    public GameObject sixRR;
    // one-six LR = Left Ring Models
    public GameObject oneLR;
    public GameObject twoLR;
    public GameObject threeLR;
    public GameObject fourLR;
    public GameObject fiveLR;
    public GameObject sixLR;
    // one-six RRPC = Right Ring Point Collider
    public GameObject oneRRPC;
    public GameObject twoRRPC;
    public GameObject threeRRPC;
    public GameObject fourRRPC;
    public GameObject fiveRRPC;
    public GameObject sixRRPC;
    // one-six LRPC = Left Ring Point Collider
    public GameObject oneLRPC;
    public GameObject twoLRPC;
    public GameObject threeLRPC;
    public GameObject fourLRPC;
    public GameObject fiveLRPC;
    public GameObject sixLRPC;

    public GameObject timerObject;
    private doubparaTimerScript timerscriptManager;

    void Start() 
    {
        timerscriptManager = timerObject.GetComponent<doubparaTimerScript>();
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
            threeRR.SetActive(true);
            StartCoroutine(threeRightHitCooldown());
            twoLRPC.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "thirdleftRingPointCollider") 
        {
            threeLR.SetActive(false);
            fiveRR.SetActive(true);
            StartCoroutine(fiveRightHitCooldown());
            threeLRPC.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "fourthleftRingPointCollider") 
        {
            fourLR.SetActive(false);
            sixRR.SetActive(true);
            StartCoroutine(sixRightHitCooldown());
            fourLRPC.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "fifthleftRingPointCollider") 
        {
            fiveLR.SetActive(false);
            sixLR.SetActive(true);
            StartCoroutine(sixLeftHitCooldown());
            fiveLRPC.SetActive(false);
            total += 1;
            correct += 1;
        }

        if(col.gameObject.tag == "sixthleftRingPointCollider") 
        {
            sixLR.SetActive(false);
            oneRR.SetActive(true);
            StartCoroutine(oneRightHitCooldown());
            sixLRPC.SetActive(false);
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

        if (col.gameObject.tag == "fifthRightRing") 
        {
            StartCoroutine(fiveRightHitCooldown());
        }

        if (col.gameObject.tag == "sixthRightRing") 
        {
            StartCoroutine(sixRightHitCooldown());
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

        if(col.gameObject.tag == "fifthrightRingPointCollider") 
        {
            fiveRRPC.SetActive(false);
            total += 1;
        }

        if(col.gameObject.tag == "sixthrightRingPointCollider") 
        {
            sixRRPC.SetActive(false);
            total += 1;
        }
    }

    IEnumerator sixLeftHitCooldown()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        sixLRPC.SetActive(true);
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

    IEnumerator fiveRightHitCooldown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        fiveRRPC.SetActive(true);
    }

    IEnumerator sixRightHitCooldown() 
    {
        yield return new WaitForSecondsRealtime(0.3f);
        sixRRPC.SetActive(true);
    }
}
