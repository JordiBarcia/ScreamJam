using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool isTimerOn;
    public TextMeshProUGUI timerTxt;

    // Start is called before the first frame update
    void Start()
    {
        isTimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerOn) {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else //Si el timer es mes petit o igual a 0 reset de posicio y pastilla
            {
                timeLeft = 0;
                isTimerOn= false;
            }
        }
    }


    void UpdateTimer(float currentTime) 
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
