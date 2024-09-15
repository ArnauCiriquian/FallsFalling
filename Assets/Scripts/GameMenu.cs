using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public string sceneName;
    public TextMeshProUGUI timerText;
    private AntMechanics antMechanics;

    void Start()
    {
        GameData.TimerValue = 0f;

        antMechanics = FindObjectOfType<AntMechanics>();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    void Update()
    {
        if (!antMechanics.IsDead)
        {
            GameData.TimerValue += Time.deltaTime;
        }
        DisplayTime(GameData.TimerValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1) * 100;

        timerText.color = Color.white;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
