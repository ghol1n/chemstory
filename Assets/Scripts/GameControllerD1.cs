using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerD1 : MonoBehaviour
{

    public static int totalTime;
    public Text timeText;

    public static GameControllerD1 instance;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = GameController1.totalTime;
        instance = this;
    }

    void Update()
    {
        if ((totalTime == 2))
        {
            StartCoroutine(Web.Cookie(Login.usuarioButom, Login.token));
        }
    }

    public void UpdateTimeText()
    {
        timeText.text = totalTime.ToString().PadLeft(4, '0');
    }
}
