using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using Mgl;

public class challange_new : MonoBehaviour
{
    public bool pontuado = false;
    public Text botao1;
    public Text botao2;
    public Text botao3;
    public Text botao4;
    public Text Pergunta;
    int posicao;
    int posicao2;
    int posicao3;
    int posicao4;
    public static string[] conteudo = {"", "", "", "", "", ""};
    public static string[] conteudoDificuldade = { "", "", "", "", "",""};
    public static string[] respostas = {"", "", "", ""};
   
    public static bool correto;
    public static int lastId;
    // List<int> respondidos = new List<int>(30);
    public static int[] respondidos = {99,99,99,99,99,99,99,99,99,99,99,99,99,99,99};
    //public static int[] respondidos;
    bool inseriu = false;
    System.Random r = new System.Random();
    int i = 0;
    public static int language;
    public static bool jarecebeu;
    public static int numPergunta;
    public I18n i18n = I18n.Instance;
    public int aa;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Web.Cookie(Login.usuarioButom, Login.token));
        correto = false;
        jarecebeu = false;
        //Debug.Log("conteudo id = "+ conteudo[0]);
        Array.Clear(conteudo, 0, 6);
        Array.Clear(respostas, 0, 4);
        Array.Clear(conteudoDificuldade, 0, 5);
       // Debug.Log(GameController1.numFase);
        getPerguntaVerificar();
    }

    void getPerguntaVerificar()
    {
        
        if (i18n.GetLocale() == "en-US")
        {
            language = 1; 
        }
        else
        {
            language = 0;
        }


        int numDificuldade = 0;
        if (GameController1.numFase <= 5)
        {
            numDificuldade = 1;
        }else if(GameController1.numFase > 5 && GameController1.numFase <= 10)
        {
            numDificuldade = 2;
        }
        else if (GameController1.numFase > 10)
        {
            numDificuldade = 3;
        }


        StartCoroutine(Web.GetIdDificuldade(numDificuldade));

        int cont = 0;
        //int aa = (r.Next(1,16));
        if (numDificuldade == 1)
        {
            aa = (r.Next(1, 6));
            while (respondidos.Contains(aa) || aa == 0)
            {
                aa = (r.Next(1, 6));

            }
        }
        if (numDificuldade == 2)
        {
            aa = (r.Next(6, 11));
            while (respondidos.Contains(aa) || aa == 0)
            {
                aa = (r.Next(6, 11));

            }
        }
        if (numDificuldade == 3)
        {
            aa = (r.Next(11, 16));
            while (respondidos.Contains(aa) || aa == 0)
            {
                aa = (r.Next(11, 16));

            }
        }

        if (respondidos.Contains(aa) || aa == 0)
        {
            if (numDificuldade == 1)
            {
                aa = (r.Next(1, 6));
                while (respondidos.Contains(aa) || aa == 0)
                {
                    aa = (r.Next(1, 6));

                }
            }
                if (numDificuldade == 2)
                {
                    aa = (r.Next(6, 11));
                    while (respondidos.Contains(aa) || aa == 0)
                    {
                        aa = (r.Next(6, 11));

                    }
                }
                if (numDificuldade == 3)
                {
                    aa = (r.Next(11, 16));
                    while (respondidos.Contains(aa) || aa == 0)
                    {
                        aa = (r.Next(11, 16));

                    }
                }
            
        }
        else
        {
            if (language == 1)
            {
                StartCoroutine(Web.GetPerguntaEng(aa));
            }
            else
            {
                StartCoroutine(Web.GetPergunta(aa));
            }
            lastId = aa;
        }

        if (aa != lastId)
        {
            if (language == 1)
            {
                StartCoroutine(Web.GetPerguntaEng(aa));
            }
            else
            {
                StartCoroutine(Web.GetPergunta(aa));
            }
            lastId = aa;
        }

    }
    // Update is called once per frame
    void Update()
    {
            if(botao1 is null)
        {
            getPerguntaVerificar();
        }
        if (i == 0){
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
        if (correto == true && pontuado == false)
        {
            Correto();
            
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
        Pergunta.text = conteudo[1];

    }

    public void verificar1()
    {
        StartCoroutine(Web.VerificarResposta(botao1.text,numPergunta));
    }
    public void verificar2()
    {
        StartCoroutine(Web.VerificarResposta(botao2.text, numPergunta));
    }
    public void verificar3()
    {
        StartCoroutine(Web.VerificarResposta(botao3.text, numPergunta));
    }
    public void verificar4()
    {
        StartCoroutine(Web.VerificarResposta(botao4.text, numPergunta));
    }




    public void Correto()
    {
        int pontuacao = (GameController1.totalScore / GameControllerD1.totalTime) * 175;
        if (pontuacao < GameController1.totalScore)
        {
            pontuacao = GameController1.totalScore;
        }
       // Debug.Log(Login.usuario);
        if (!SceneManager.GetActiveScene().name.Contains("Eng"))
            StartCoroutine(Web.Pontuar(GameController1.numFase, GameController1.totalScore, GameControllerD1.totalTime, Login.usuario, pontuacao));
        else
            StartCoroutine(Web.PontuarEng(GameController1.numFase, GameController1.totalScore, GameControllerD1.totalTime, Login.usuario, pontuacao));

        if(inseriu == false) { 
            respondidos[GameController1.numFase - 1] = lastId; 
            for (int i = 0; i < 15; i++) 
            { Debug.Log("LISTA " + (i+1) + ": " + respondidos[i]); }
            Debug.Log("NumFase: "+GameController1.numFase);
            inseriu = true;
        }
        pontuado = true;
    }





}
