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
        if ((SceneManager.GetActiveScene().name).Contains("4")) numFase = 4;
        if ((SceneManager.GetActiveScene().name).Contains("5")) numFase = 5;
        if ((SceneManager.GetActiveScene().name).Contains("6")) numFase = 6;
        if ((SceneManager.GetActiveScene().name).Contains("7")) numFase = 7;
        if ((SceneManager.GetActiveScene().name).Contains("8")) numFase = 8;
        if ((SceneManager.GetActiveScene().name).Contains("9")) numFase = 9;
        if ((SceneManager.GetActiveScene().name).Contains("10")) numFase = 10;
        if ((SceneManager.GetActiveScene().name).Contains("11")) numFase = 11;
        if ((SceneManager.GetActiveScene().name).Contains("12")) numFase = 12;
        if ((SceneManager.GetActiveScene().name).Contains("13")) numFase = 13;
        if ((SceneManager.GetActiveScene().name).Contains("14")) numFase = 14;
        if ((SceneManager.GetActiveScene().name).Contains("15")) numFase = 15;
        totalScore = 0;
        totalTime = 0;
        instance = this;
        nomeFase = (SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (totalTime == 2)
        {
            StartCoroutine(Web.Cookie(Login.usuarioButom, Login.token));
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
