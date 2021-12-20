using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRanking : MonoBehaviour
{
    public static string pontuacao;
    public Text PontuacaoFim;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Web.GetRanking());
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
