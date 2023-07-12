using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 180;
    public bool timerIsRunning = false;

    public GameObject ssrManager;
    private ssrScript scriptManager;

    private UIButtonScript buttonscript;

    public GameObject rightRingModel;
    public GameObject leftRingModel;

    public GameObject rudimentCompleteUI;

    public TextMeshProUGUI timeText;

    private void Start()
    {
        scriptManager = ssrManager.GetComponent<ssrScript>();
    }
    void Update()
    {
        if (scriptManager.startButton == true)
        {
            Debug.Log(scriptManager.startButton);
            leftRingModel.SetActive(true);

            if (timeRemaining > 0)
            {
                if (rightRingModel.activeSelf)
                {
                    leftRingModel.SetActive(false);
                }
                
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                Debug.Log(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                leftRingModel.SetActive(false);
                rightRingModel.SetActive(false);
                rudimentCompleteUI.SetActive(true);
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