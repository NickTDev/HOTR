using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceTimerScript : MonoBehaviour
{
    Image timerBar;
    float timeLeft;
    float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        maxTime = GetComponentInParent<DeviceScript>().waitTimer;
        timeLeft = 0.0f;
        timerBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
    }

    public void startTimer()
    {
        timeLeft = maxTime;
    }
}
