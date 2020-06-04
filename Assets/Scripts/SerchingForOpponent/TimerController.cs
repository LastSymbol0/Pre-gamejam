using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TimerController : MonoBehaviour
{
    public Text DebugTimerText;
    public TextMeshProUGUI TimerText;

    float TimeLeft = 0.0f;
    float TimeToShowTimer = 3.5f;

    void Start()
    {
        TimeLeft = UnityEngine.Random.Range(4.0f, 10.0f);
    }

    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < TimeToShowTimer)
        {
            TimerText.text = Math.Round(TimeLeft).ToString();
        }
        DebugTimerText.text = Math.Round(TimeLeft).ToString();

        if (TimeLeft <= 0.0f)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        //TimerText.SetActive(false);
        SceneManager.LoadScene("Game");
    }
}
