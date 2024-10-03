//Scott Abbinanti 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private bool timerActive = false;
    private float currentTime;

    public SpaceshipController spaceshipController;

    [SerializeField] private TMP_Text timerText;
    public GameObject warning;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        spaceshipController = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceshipController>();
        audio = GetComponent<AudioSource>();
        currentTime = 0;
        //timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime += Time.deltaTime;
        }
        //timerText.text = currentTime.ToString();

        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        timerText.text = time.Minutes.ToString() + " : " + time.Seconds.ToString() + " : " + time.Milliseconds.ToString();
        if (time.Minutes == 1 && time.Seconds >= 2 && time.Milliseconds >= 560)
        {
            //spaceshipController.playerAudio.Pause();
            warning.SetActive(true);
            audio.Play();
        }


        if (time.Minutes == 1 && time.Seconds >= 12 && time.Milliseconds >= 236)
        {
            warning.SetActive(false);
            StopTimer();
            timerText.text = "";
            spaceshipController.won = true;
        }
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
