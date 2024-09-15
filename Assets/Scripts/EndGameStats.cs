using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameStats : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Start()
    {
        int minutes = (int)(GameData.TimerValue / 60);
        int seconds = (int)(GameData.TimerValue % 60);
        int milliseconds = (int)((GameData.TimerValue - (minutes * 60 + seconds)) * 1000);

        string timeString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

        timerText.text = timeString;
    }
}
