using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class Challange_test : MonoBehaviour
{
    public Text botao1;
    public Text botao2;
    public Text botao3;
    public Text botao4;
    int posicao;
    int posicao2;
    int posicao3;
    int posicao4;
    public string[] respostas = { "Criptônio (Kr)", "Hélio (He)", "Argônio (Ar)", "Radônio (Rn)" };
    System.Random rnd = new System.Random();
    System.Random r = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Sort();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Sort()
    {
        posicao = r.Next(respostas.Length);

        while (posicao4 == posicao || posicao4 == posicao2 || posicao4 == posicao3)
        {
            posicao4 = r.Next(respostas.Length);

            while (posicao3 == posicao || posicao3 == posicao2)
            {
                posicao3 = r.Next(respostas.Length);
                while (posicao2 == posicao)
                {
                    posicao2 = r.Next(respostas.Length);

                }
            }
        }
        botao1.text = respostas[posicao];
        botao2.text = respostas[posicao2];
        botao3.text = respostas[posicao3];
        botao4.text = respostas[posicao4];

    }

    public void verificar1()
    {
        if(botao1.text.Contains("He"))
        {
            Correto();
        }
        else {
            SceneManager.LoadScene("errado");
        }
    }
    public void verificar2()
    {
        if (botao2.text.Contains("He"))
        {
            Correto();
        }
        else
        {
            SceneManager.LoadScene("errado");
        }
    }
    public void verificar3()
    {
        if (botao3.text.Contains("He"))
        {
            Correto();
        }
        else
        {
            SceneManager.LoadScene("errado");
        }
    }
    public void verificar4()
    {
        if (botao4.text.Contains("He"))
        {
            Correto();
        }
        else
        {
            SceneManager.LoadScene("errado");
        }
    }




    public void Correto()
    {
        int pontuacao = (GameController1.totalScore / GameControllerD1.totalTime) * 175;
        if (pontuacao < GameController1.totalScore)
        {
            pontuacao = GameController1.totalScore;
        }
        //  Debug.Log(GameController1.totalScore);
        // Debug.Log(GameControllerD1.totalTime);
        Debug.Log(Login.usuario);
        // Debug.Log(pontuacao);

        StartCoroutine(Web.Pontuar(GameController1.numFase, GameController1.totalScore, GameControllerD1.totalTime, Login.usuario, pontuacao));


    }

}
