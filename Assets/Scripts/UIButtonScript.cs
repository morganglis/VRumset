using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIButtonScript : MonoBehaviour
{
    public UnityEvent onPress;
    public UnityEvent onRelease;

    Collider presser;
 
    bool isPressed;
    bool enabled { get; set; }

    void Start()
    {
        isPressed = false;
        enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && enabled)
        {
            onPress.Invoke();
            presser = other;
            isPressed = true;
        }
    }

}