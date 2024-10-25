using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeftStart;
    private float timeLeft;
    public bool isTimerOn;
    public TextMeshProUGUI timerTxt;
    private Animator transitionAnimator;
    private int sceneIndex;
    public Dialogue dialogue;
    public GameObject player;
    private Vector3 startPositionPlayer;
    private float timeRestart;

    // Start is called before the first frame update
    void Start()
    {
        isTimerOn = true;
        transitionAnimator = GetComponent<Animator>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        startPositionPlayer = player.transform.position;
        timeRestart = 2.1f;
        timeLeft = timeLeftStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else //Si el timer es mes petit o igual a 0 reset de posicio y pastilla
            {
                timeLeft = 0;
                isTimerOn = false;
                //Fade();
            }
        }
        else
        {
            Restart();
        }
        if (dialogue.isMother) 
        {
            SceneLoad();
        }
    }
    public void Restart() 
    {
        //SceneLoad();
        if (timeRestart == 2.1f) Fade();
        timeRestart -= Time.deltaTime;
        if(timeRestart < 0.15f && timeRestart > 0.1f) player.transform.position = startPositionPlayer;
        if (timeRestart <= 0)
        {
            timeRestart = 2.1f;
            isTimerOn = true;
            timeLeft = timeLeftStart;
            transitionAnimator.SetTrigger("EndTransition");
        }

    }
    public void Fade()
    {
        transitionAnimator.SetTrigger("StartTransition");
    }
    public IEnumerator SceneLoad()
    {
        isTimerOn = false;
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadScene(sceneIndex);
        
    }
    void UpdateTimer(float currentTime) 
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
