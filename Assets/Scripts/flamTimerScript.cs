using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class flamTimerScript : MonoBehaviour {

    public float timeRemaining = 60;
    public bool timerIsRunning;

    public GameObject flamManager;
    private flamScript scriptManager;

    public GameObject leftRingPointCollider;
    public GameObject rightRingModel;
    public GameObject secondrightRingModel;
    public GameObject secondleftRingModel;
    public GameObject leftRingModel;
    public GameObject flamInProgressUI;

    public TextMeshProUGUI timeText;

    public AudioClip input;
    public AudioSource Success;

    private void Start()
    {
        scriptManager = flamManager.GetComponent<flamScript>(); // Grab out flamManagerScript
    }

    void Update()
    {
        if (scriptManager.startButton == true)  // If the start button has been pressed
        {
            leftRingModel.SetActive(true);  // Left ring model will now appear
            leftRingPointCollider.SetActive(true);  // Left ring collider will also appear
            scriptManager.startButton = false;  // Start button state is now set to false

            if (rightRingModel.activeSelf)  // Ensures that if the right ring model is active, then the left model and collider are not
            {
                leftRingModel.SetActive(false);
                leftRingPointCollider.SetActive(false);
            }
        }

        if (flamInProgressUI.activeSelf == true) // If the text "In Progress..." is currently active
        {    
            
            if (timeRemaining > 0)  // If the time remaining is above 0, the timeRemaining variable will begin to count down and displayed
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining); // Pass our timeRemaining variable into our time display method
            }

            else    // If the time remaining is not above zero, then the timeRemaining is 0 and both rings states are set to inactive
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Success.PlayOneShot(input);
                leftRingModel.SetActive(false);
                secondleftRingModel.SetActive(false);
                rightRingModel.SetActive(false);
                secondrightRingModel.SetActive(false);


            }
        }
    }

    void DisplayTime(float timeToDisplay) // Method to display the countdown timer
    {
        timeToDisplay += 1;     // Counts up by 1 as the timeRemaining counts down in order for the time to be displayed as a countDOWN
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);   // Converts our calculated minutes and seconds to string format and displays them like "0:00"
    }
}