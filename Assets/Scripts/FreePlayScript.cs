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

    public bool isPressed;

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

        if (UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger)) {
            isPressed = true;
        
        }

        else if (!(UxrAvatar.LocalAvatarInput.GetButtonsPress(UxrHandSide.Left, UxrInputButtons.Trigger))) {
            isPressed = false;
        
        }

        // if (isPressed) {
            
        //     hihat.transform.position = new Vector3(0.03412427f, -0.03703818f, 0.1833f);

        //     //0.1861966
        // }

        // else if (!isPressed) {
        //     hihat.transform.position = new Vector3(0.03412427f, -0.03703818f, 0.1861966f);

        // }
        }
        
    }

        


