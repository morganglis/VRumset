using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class doubparaTimerScript : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timerIsRunning;

    public GameObject doubparaManager;
    private doubparaScript scriptManager;

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

    public GameObject doubparaInProgressUI;

    public TextMeshProUGUI timeText;

    public AudioClip input;
    public AudioSource Success;

    private void Start()
    {
        scriptManager = doubparaManager.GetComponent<doubparaScript>(); // Grab out ssrManagerScript
    }

    void Update()
    {
        if (scriptManager.startButton == true)  // If the start button has been pressed
        {
            oneRR.SetActive(true);  // Right ring model will now appear
            oneRRPC.SetActive(true);  // Right ring collider will also appear
            scriptManager.startButton = false;  // Start button state is now set to false

            if (oneLR.activeSelf || twoLR.activeSelf)  // Ensures that if the first/second LR is active, then the left model and collider are not
            {
                oneRR.SetActive(false);
                oneRRPC.SetActive(false);
            }
        }

        if(doubparaInProgressUI.activeSelf == true) // If the text "In Progress..." is currently active
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
                oneRR.SetActive(false);
                twoRR.SetActive(false);
                threeRR.SetActive(false);
                fourRR.SetActive(false);
                oneLR.SetActive(false);
                twoLR.SetActive(false);
                threeLR.SetActive(false);
                fourLR.SetActive(false);
                oneRRPC.SetActive(false);
                twoRRPC.SetActive(false);
                threeRRPC.SetActive(false);
                fourRRPC.SetActive(false);
                oneLRPC.SetActive(false);
                twoLRPC.SetActive(false);
                threeLRPC.SetActive(false);
                fourLRPC.SetActive(false);

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
