using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timerIsRunning;

    public GameObject ssrManager;
    private ssrScript scriptManager;

    private UIButtonScript buttonscript;

    public GameObject rightRingModel;
    public GameObject leftRingModel;

    public GameObject rudimentCompleteUI;
    public GameObject ssRInProgressUI;

    public TextMeshProUGUI timeText;

    public GameObject leftRingPointCollider;

    public bool startFlag;

    private void Start()
    {
        scriptManager = ssrManager.GetComponent<ssrScript>();
    }
    void Update()
    {
        if (scriptManager.startButton == true)
        {
            leftRingModel.SetActive(true);
            leftRingPointCollider.SetActive(true);
            scriptManager.startButton = false;
            if (rightRingModel.activeSelf)
            {
                leftRingModel.SetActive(false);
                leftRingPointCollider.SetActive(false);
            }
        }

        if(ssRInProgressUI.activeSelf == true) {
            
            if (timeRemaining > 0)

            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                leftRingModel.SetActive(false);
                rightRingModel.SetActive(false);
                startFlag = false;
            }}

        
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}