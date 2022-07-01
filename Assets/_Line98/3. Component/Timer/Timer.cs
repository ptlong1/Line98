using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
	public TMP_Text timerText;
	float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time - startTime;
		TimeSpan time = TimeSpan.FromSeconds(currentTime);
		timerText.text = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
    }
}
