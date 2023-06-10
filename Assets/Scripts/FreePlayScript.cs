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

    public AudioClip input8;
    public AudioSource Kick;

    private float soundStart = 0f;
    private float soundCooldown = 0.4f;

    void Update()
    {
        
        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Trigger) && Time.time > soundStart + soundCooldown) 
    {

        // Play some animation
            Kick.pitch = Random.Range(0.8f,1.2f);
            Kick.PlayOneShot(input8);
            soundStart = Time.time;
            UxrAvatar.LocalAvatar.ControllerInput.SendHapticFeedback(UxrHandSide.Right, UxrHapticClipType.Click, 1.0f);

    }

        // if (UxrAvatar.LocalAvatarInput.GetButtonsEvent(UxrHandSide.Left, UxrInputButtons.Trigger, UxrButtonEventType.PressDown)) {
        //     // some animation for hi hat
        // }
        
    }

        

    
    
}
