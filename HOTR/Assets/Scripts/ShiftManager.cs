using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShiftManager : MonoBehaviour
{
    Image timerBar;
    float timeLeft;
    public float maxTime;

    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();;
        timeLeft = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startTimer();
        }

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }

        if (timeLeft < 0)
        {
            if (GameObject.Find("DebtManager").GetComponent<DebtManager>().currentShiftEarnings < GameObject.Find("DebtManager").GetComponent<DebtManager>().currentShiftQuota)
                winText.text = "You Failed The Shift!";

            winText.enabled = true;
        }
    }

    public void startTimer()
    {
        timeLeft = maxTime;
    }
}
