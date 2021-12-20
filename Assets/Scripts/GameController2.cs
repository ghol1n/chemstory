using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    public static int numFase = 2;

    public static int totalScore;
    public Text scoreText;

    public static int totalTime;
    public Text timeText;

    public static GameController1 instance;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        totalTime = 0;
      //  instance = this;
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
