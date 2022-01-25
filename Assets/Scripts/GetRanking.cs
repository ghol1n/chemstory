using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mgl;

public class GetRanking : MonoBehaviour
{
    public static string total;
    public static string apelido;
    public TMP_Text nickname;
    public TMP_Text pontuacao;
    public TMP_Text Apelido;
    public TMP_Text Pontuacao;
    private I18n i18n = I18n.Instance;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        nickname.text = null;
        pontuacao.text = null;
        StartCoroutine(Web.GetRankingApelido());
        StartCoroutine(Web.GetRankingTotal());
        
    }

    // Update is called once per frame
    void Update()
    {
        Apelido.text = i18n.__("Nickname");
        Pontuacao.text = i18n.__("Points");
        if (System.String.IsNullOrEmpty(nickname.text) || System.String.IsNullOrEmpty(pontuacao.text))
        {
            nickname.text = total;
            pontuacao.text = apelido;
        }
    }
    void atualizar()
    {
        i = 0;
        while (i < 25)
        {
            nickname.text = total;
            pontuacao.text = apelido;
        }
    }
}
