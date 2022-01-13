using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetRanking : MonoBehaviour
{
    public static string total;
    public static string apelido;
    public TMP_Text nickname;
    public TMP_Text pontuacao;
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
