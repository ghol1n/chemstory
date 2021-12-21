using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesafioControllerEng : MonoBehaviour
{


    public string currentlevel;
    public int numfase;
    // Start is called before the first frame update
    void Start()
    {
        currentlevel = GameController1.nomeFase;
        numfase = GameController1.numFase;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Correto()
    {
        int pontuacao = (GameController1.totalScore / GameControllerD1.totalTime) * 175;
        if(pontuacao < GameController1.totalScore)
        {
            pontuacao = GameController1.totalScore;
        }
        //  Debug.Log(GameController1.totalScore);
        // Debug.Log(GameControllerD1.totalTime);
        Debug.Log(Login.usuario);
        // Debug.Log(pontuacao);

        StartCoroutine(Web.PontuarEng(GameController1.numFase, GameController1.totalScore, GameControllerD1.totalTime, Login.usuario, pontuacao));


    }


    public void Errado()
    {
        SceneManager.LoadScene("ErradoEng");
    }

    public void reload()
    {
        SceneManager.LoadScene(currentlevel);
    }
    public void nextLevel()
    {
        SceneManager.LoadScene("lvl_" + (numfase + 1).ToString() + "Eng");
    }
    public void menu()
    {
        SceneManager.LoadScene("LoginEng");
    }
    public void ranking()
    {
        SceneManager.LoadScene("RankingEng");
    }

}


/// ////////////////////


