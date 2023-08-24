using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;
using UltimateXR.Devices;

public class doubparaRightStickManager : MonoBehaviour
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

    public bool isPressed;  // isPressed is a bool that is important to the functionality of a closed vs. open hi hat

    private float soundStart = 0f;  // Important variables to ensure that our drum heads and cymbals all have cooldowns and can't just make repeated nonsense noise
    private float soundCooldown = 0.4f;

    public Animation crashAnimation;
    public Animation rideAnimation;

    public float timeRemaining;
    public float total = 0;
    public float correct = 0;

    public GameObject doubparaManager;
    private doubparaScript scriptManager;

    public GameObject timerObject;
    private doubparaTimerScript timerscriptManager;

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

    void Start() 
    {
        scriptManager = doubparaManager.GetComponent<doubparaScript>();   // Grab our doubparaManager script
        timerscriptManager = timerObject.GetComponent<doubparaTimerScript>();   // Grab our timer script
    }

    void Update() 
    {
        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger))  // If the left controller trigger is pressed
        {
            isPressed = true;
        }

        else if (!(UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger))) // If the left controller trigger is not pressed
        {
            isPressed = false;
        }
    }  

    void OnCollisionEnter(Collision col) // The big collider method which associates all our drum head & cymbal colliders and what sound/animation they should play when struck by the right stick
    {
        if (col.gameObject.tag == "Snare" && Time.time > soundStart + soundCooldown)    // This ensures that our right stick is colliding with the snare and ensures that the sound and haptic feedback is not sent back unless the cooldown has succeeded
        {
            Snare.PlayOneShot(input);   // PlayOneShot plays the audio once so we don't have audio interruptions by too quick of hits
            soundStart = Time.time; // Resets our soundStart to the current time
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); // Sends haptic feedback to the right controller on collision
        }

        if (col.gameObject.tag == "HiHat" && Time.time > soundStart + soundCooldown && !(isPressed)) 
        {
            HiHat.PlayOneShot(input2);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "HiHat" && Time.time > soundStart + soundCooldown && isPressed) 
        {
            HiHatClosed.PlayOneShot(input9);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Crash1" && Time.time > soundStart + soundCooldown) 
        {
            Crash1.PlayOneShot(input3);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); 
            crashAnimation.Play();
        }

        if (col.gameObject.tag == "Crash2" && Time.time > soundStart + soundCooldown) 
        {
            Crash2.PlayOneShot(input4);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); 
            rideAnimation.Play();
        }

        if (col.gameObject.tag == "Floor" && Time.time > soundStart + soundCooldown) 
        {
            Floor.PlayOneShot(input7);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Tom1" && Time.time > soundStart + soundCooldown) 
        {
            Crash2.PlayOneShot(input5);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Tom2" && Time.time > soundStart + soundCooldown) 
        {
            Tom2.PlayOneShot(input6);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f); 
        }

        if(col.gameObject.tag == "rightRingPointCollider") // If the right stick (correctly) collides with the right ring point collider then:
        {
            oneRRPC.SetActive(false);    // The right ring point collider state is now inactive
            oneRR.SetActive(false);
            oneLR.SetActive(true);  // The left ring is now set to active
            StartCoroutine(oneLeftHitCooldown());
            total += 1; // Total points increments by one
            correct += 1;   // Correct points increments by one
        }

        if(col.gameObject.tag == "secondrightRingPointCollider") // If the right stick (correctly) collides with the right ring point collider then:
        {

            twoRR.SetActive(false); // The right ring is set to inactive
            twoLR.SetActive(true);  // The left ring is now set to active
            StartCoroutine(twoLeftHitCooldown());
            twoRRPC.SetActive(false);
            total += 1; // Total points increments by one
            correct += 1;   // Correct points increments by one

        }

        if(col.gameObject.tag == "thirdrightRingPointCollider") // If the right stick (correctly) collides with the right ring point collider then:
        {

            threeRR.SetActive(false); // The right ring is set to inactive
            fourRR.SetActive(true);  // The left ring is now set to active
            StartCoroutine(fourRightHitCooldown());
            threeRRPC.SetActive(false);
            total += 1; // Total points increments by one
            correct += 1;   // Correct points increments by one
        }

        if(col.gameObject.tag == "fourthrightRingPointCollider") // If the right stick (correctly) collides with the right ring point collider then:
        {

            fourRR.SetActive(false); // The right ring is set to inactive
            threeLR.SetActive(true);  // The left ring is now set to active
            StartCoroutine(threeLeftHitCooldown());
            fourRRPC.SetActive(false);
            total += 1; // Total points increments by one
            correct += 1;   // Correct points increments by one
        }

        if(col.gameObject.tag == "fifthrightRingPointCollider") // If the right stick (correctly) collides with the right ring point collider then:
        {

            fiveRR.SetActive(false); // The right ring is set to inactive
            fourLR.SetActive(true);  // The left ring is now set to active
            StartCoroutine(fourLeftHitCooldown());
            fiveRRPC.SetActive(false);
            total += 1; // Total points increments by one
            correct += 1;   // Correct points increments by one
        }

        if(col.gameObject.tag == "sixthrightRingPointCollider") // If the right stick (correctly) collides with the right ring point collider then:
        {

            sixRR.SetActive(false); // The right ring is set to inactive
            fiveLR.SetActive(true);  // The left ring is now set to active
            StartCoroutine(fiveLeftHitCooldown());
            sixRRPC.SetActive(false);
            total += 1; // Total points increments by one
            correct += 1;   // Correct points increments by one
        }

        if (col.gameObject.tag == "leftRing") // If the collision (a wrong one) occurs with the left ring
        {
            StartCoroutine(oneLeftHitCooldown());   // The cooldown coroutine is called
        }

        if (col.gameObject.tag == "secondLeftRing") // If the collision (a wrong one) occurs with the left ring
        {
            StartCoroutine(twoLeftHitCooldown());   // The cooldown coroutine is called
        }

        if (col.gameObject.tag == "thirdLeftRing") // If the collision (a wrong one) occurs with the left ring
        {
            StartCoroutine(threeLeftHitCooldown());   // The cooldown coroutine is called
        }

        if (col.gameObject.tag == "fourthLeftRing") // If the collision (a wrong one) occurs with the left ring
        {
            StartCoroutine(fourLeftHitCooldown());   // The cooldown coroutine is called
        }

        if (col.gameObject.tag == "fifthLeftRing") // If the collision (a wrong one) occurs with the left ring
        {
            StartCoroutine(fiveLeftHitCooldown());   // The cooldown coroutine is called
        }

        if (col.gameObject.tag == "sixthLeftRing") // If the collision (a wrong one) occurs with the left ring
        {
            StartCoroutine(sixLeftHitCooldown());   // The cooldown coroutine is called
        }

        if(col.gameObject.tag == "leftRingPointCollider") // If the right stick (incorrectly) collides with the left ring point collider then:
        {
            oneLRPC.SetActive(false); // The left ring point collider state is set to inactive
            total += 1; // The total points increment by one, correct does not increase because this was not a correct hit by the user
        }

        if(col.gameObject.tag == "secondleftRingPointCollider") // If the right stick (incorrectly) collides with the left ring point collider then:
        {
            twoLRPC.SetActive(false); // The left ring point collider state is set to inactive
            total += 1; // The total points increment by one, correct does not increase because this was not a correct hit by the user
        }

        if(col.gameObject.tag == "thirdleftRingPointCollider") // If the right stick (incorrectly) collides with the left ring point collider then:
        {
            threeLRPC.SetActive(false); // The left ring point collider state is set to inactive
            total += 1; // The total points increment by one, correct does not increase because this was not a correct hit by the user
        }

        if(col.gameObject.tag == "fourthleftRingPointCollider") // If the right stick (incorrectly) collides with the left ring point collider then:
        {
            fourLRPC.SetActive(false); // The left ring point collider state is set to inactive
            total += 1; // The total points increment by one, correct does not increase because this was not a correct hit by the user
        }

        if(col.gameObject.tag == "fifthleftRingPointCollider") // If the right stick (incorrectly) collides with the left ring point collider then:
        {
            fiveLRPC.SetActive(false); // The left ring point collider state is set to inactive
            total += 1; // The total points increment by one, correct does not increase because this was not a correct hit by the user
        }

        if(col.gameObject.tag == "sixthleftRingPointCollider") // If the right stick (incorrectly) collides with the left ring point collider then:
        {
            sixLRPC.SetActive(false); // The left ring point collider state is set to inactive
            total += 1; // The total points increment by one, correct does not increase because this was not a correct hit by the user
        }
    }

    IEnumerator oneLeftHitCooldown() // Cooldown method that gives a bit of delay to prevent double counted hits to the total/correct variables
    {
        yield return new WaitForSecondsRealtime(0.3f);
        oneLRPC.SetActive(true);
    }

    IEnumerator twoLeftHitCooldown() // Third Cooldown method that gives a bit of delay to prevent double counted hits to the total/correct variables
    {
        yield return new WaitForSecondsRealtime(0.3f);
        twoLRPC.SetActive(true);
    }

    IEnumerator threeLeftHitCooldown() // Third Cooldown method that gives a bit of delay to prevent double counted hits to the total/correct variables
    {
        yield return new WaitForSecondsRealtime(0.3f);
        threeLRPC.SetActive(true);
    }

    IEnumerator fourLeftHitCooldown() // Third Cooldown method that gives a bit of delay to prevent double counted hits to the total/correct variables
    {
        yield return new WaitForSecondsRealtime(0.3f);
        fourLRPC.SetActive(true);
    }

    IEnumerator fiveLeftHitCooldown() // Third Cooldown method that gives a bit of delay to prevent double counted hits to the total/correct variables
    {
        yield return new WaitForSecondsRealtime(0.3f);
        fiveLRPC.SetActive(true);
    }

    IEnumerator sixLeftHitCooldown() // Third Cooldown method that gives a bit of delay to prevent double counted hits to the total/correct variables
    {
        yield return new WaitForSecondsRealtime(0.3f);
        sixLRPC.SetActive(true);
    }

    IEnumerator fourRightHitCooldown() // Second Cooldown method that gives a bit of delay to prevent double counted hits to the total/correct variables
    {
        yield return new WaitForSecondsRealtime(0.3f);
        fourRRPC.SetActive(true);
    }

}
