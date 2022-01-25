using Mgl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPontuacaoFase : MonoBehaviour
{
    public static string pontuacao;
    public Text PontuacaoFim;
    public Text Titulo;
    public Text Botao;
    public Text Botao2;
    public I18n i18n = I18n.Instance;
    // Start is called before the first frame update
    void Start()
    {
        Titulo.text = i18n.__("Level Completed!");
        Botao.text = i18n.__("Next");
        Botao2.text = i18n.__("See Ranking");
        if (i18n.GetLocale() == "en-US") { 
        StartCoroutine(Web.GetPontuacaoEng(Login.usuario, GameController1.numFase));
        }
        else
        {
            StartCoroutine(Web.GetPontuacao(Login.usuario, GameController1.numFase));
        }
        InvokeRepeating("atualizar", 1f, 1f);


    }

    public void atualizar()
    {
        PontuacaoFim.text = pontuacao;
        Debug.Log(PontuacaoFim);
        Debug.Log(pontuacao);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
