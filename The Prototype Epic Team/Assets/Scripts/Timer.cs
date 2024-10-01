using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private bool timerActive = false;
    private float currentTime;

    [SerializeField] private TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
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
