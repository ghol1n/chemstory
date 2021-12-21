using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRanking : MonoBehaviour
{
    public static string total;
    public static string apelido;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Web.GetRankingApelido());
        StartCoroutine(Web.GetRankingTotal());
    }

    // Update is called once per frame
    void Update()
    {

    }

}
