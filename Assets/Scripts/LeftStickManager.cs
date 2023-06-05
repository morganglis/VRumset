using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Avatar;
using UltimateXR.Haptics;
using UltimateXR.Core;

public class LeftStickManager : MonoBehaviour
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

    private float snareStart = 0f;
    private float snareCooldown = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "Snare" && Time.time > snareStart + snareCooldown) 
        {
            Snare.PlayOneShot(input);
            snareStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "HiHatOpen" && Time.time > snareStart + snareCooldown) 
        {
            HiHat.PlayOneShot(input2);
            snareStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Crash1" && Time.time > snareStart + snareCooldown) 
        {
            Crash1.PlayOneShot(input3);
            snareStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Crash2" && Time.time > snareStart + snareCooldown) 
        {
            Crash2.PlayOneShot(input4);
            snareStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Floor" && Time.time > snareStart + snareCooldown) 
        {
            Floor.PlayOneShot(input7);
            snareStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Tom1" && Time.time > snareStart + snareCooldown) 
        {
            Crash2.PlayOneShot(input5);
            snareStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }

        if (col.gameObject.tag == "Tom2" && Time.time > snareStart + snareCooldown) 
        {
            Tom2.PlayOneShot(input6);
            snareStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Left, UxrHapticClipType.Click, 1.0f); 
        }
    }

private IEnumerator DelayedAction()
{
    yield return new WaitForSeconds(1);
    print("I was printed after a delay of 1 seconds!");
}
}