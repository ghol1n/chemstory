using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesafioController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Correto()
    {
        int pontuacao = (GameController1.totalScore / GameControllerD1.totalTime) * 100;

        //  Debug.Log(GameController1.totalScore);
        // Debug.Log(GameControllerD1.totalTime);
        Debug.Log(Login.usuario);
        // Debug.Log(pontuacao);

        StartCoroutine(Web.Pontuar(1, GameController1.totalScore, GameControllerD1.totalTime, Login.usuario, pontuacao)); 
        

    }


    public void Errado()
    {
        SceneManager.LoadScene("lvl_1");
    }

}


/// ////////////////////

