using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController1 : MonoBehaviour
{
    public static int numFase;
    public static string nomeFase;

    public static int totalScore;
    public  Text scoreText;

    public static int totalTime;
    public  Text timeText;

    public static GameController1 instance;

    // Start is called before the first frame update
    void Start()
    {
        if ((SceneManager.GetActiveScene().name).Contains("1")) numFase = 1;
        if ((SceneManager.GetActiveScene().name).Contains("2")) numFase = 2;
        if ((SceneManager.GetActiveScene().name).Contains("3")) numFase = 3;
        totalScore = 0;
        totalTime = 0;
        instance = this;
        nomeFase = (SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if (totalTime == 2)
        {
            StartCoroutine(Web.Cookie());
            totalTime = 3;
        }
    }
    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString().PadLeft(4, '0');

    }
    public void UpdateTimeText()
    {
        timeText.text = totalTime.ToString().PadLeft(4, '0');
    }
}
