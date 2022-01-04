using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class challange_newEng : MonoBehaviour
{
    public Text botao1;
    public Text botao2;
    public Text botao3;
    public Text botao4;
    public Text Pergunta;
    int posicao;
    int posicao2;
    int posicao3;
    int posicao4;
    public static string[] conteudo = { "", "", "", "", "" };
    public static string[] respostas = { "", "", "", "" };
    System.Random rnd = new System.Random();
    System.Random r = new System.Random();
    int i = 0;


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(GameController1.numFase);
        StartCoroutine(Web.GetPerguntaEng(GameController1.numFase));

        //while (System.String.IsNullOrEmpty(respostas[0])) { Sort(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            if (System.String.IsNullOrEmpty(respostas[0]))
            {
                Sort();
            }
            if (!System.String.IsNullOrEmpty(respostas[0]))
            {
                Sort();
                i = 1;
            }
        }

    }
    void Sort()
    {
        int i = 0;
        posicao = r.Next(respostas.Length);
        posicao2 = r.Next(respostas.Length);
        posicao3 = r.Next(respostas.Length);
        posicao4 = r.Next(respostas.Length);

        if (i == 0)
        {
            while (posicao2 == posicao || posicao2 == posicao3 || posicao2 == posicao4)
            {
                posicao2 = r.Next(respostas.Length);
            }
            i = 1;
        }
        if (i == 1)
        {
            while (posicao3 == posicao || posicao3 == posicao4 || posicao3 == posicao2)
            {
                posicao3 = r.Next(respostas.Length);
            }
            i = 2;
        }
        if (i == 2)
        {
            while (posicao4 == posicao || posicao4 == posicao2 || posicao4 == posicao3)
            {
                posicao4 = r.Next(respostas.Length);
            }
            i = 2;
        }
        botao1.text = respostas[posicao];
        botao2.text = respostas[posicao2];
        botao3.text = respostas[posicao3];
        botao4.text = respostas[posicao4];
        Pergunta.text = conteudo[0];

    }

    public void verificar1()
    {
        if (botao1.text.Equals(respostas[0]))
        {
            Correto();
        }
        else
        {
            SceneManager.LoadScene("ErradoEng");
        }
    }
    public void verificar2()
    {
        if (botao2.text.Equals(respostas[0]))
        {
            Correto();
        }
        else
        {
            SceneManager.LoadScene("ErradoEng");
        }
    }
    public void verificar3()
    {
        if (botao3.text.Equals(respostas[0]))
        {
            Correto();
        }
        else
        {
            SceneManager.LoadScene("ErradoEng");
        }
    }
    public void verificar4()
    {
        if (botao4.text.Equals(respostas[0]))
        {
            Correto();
        }
        else
        {
            SceneManager.LoadScene("ErradoEng");
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

        StartCoroutine(Web.PontuarEng(GameController1.numFase, GameController1.totalScore, GameControllerD1.totalTime, Login.usuario, pontuacao));


    }

}
