using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 180;
    public bool timerIsRunning;

    public GameObject ssrManager;
    private ssrScript scriptManager;

    private UIButtonScript buttonscript;

    public GameObject rightRingModel;
    public GameObject leftRingModel;
    public GameObject startRingModel;

    public GameObject rudimentCompleteUI;

    public TextMeshProUGUI timeText;

    public GameObject leftRingPointCollider;

    private void Start()
    {
        scriptManager = ssrManager.GetComponent<ssrScript>();
    }
    void Update()
    {
        if (scriptManager.startButton == true)
        {
            startRingModel.SetActive(true);
            leftRingModel.SetActive(true);

            if (timeRemaining > 0)
            {
                timerIsRunning = true;
                if (rightRingModel.activeSelf)
                {
                    startRingModel.SetActive(false);
                    leftRingModel.SetActive(false);
                }
                
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                leftRingModel.SetActive(false);
                rightRingModel.SetActive(false);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}