using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;
using System.Net;

public class SenhaEnviada : MonoBehaviour

{
    public static string result;
    public Text mensagem;
    string textoMensagem = "sua senha foi enviada ao e-mail de seguranca '"+result+"'. nao esque«a de checar a caixa de spam. =)";
    
    public float altura;
    void Start()
    {
        StartCoroutine(ShowText());
    }
    void Update()
    {

    }

    IEnumerator ShowText()
    {
        int count = 0;
        while (count < textoMensagem.Length)
        {
            yield return new WaitForSeconds(0.05f);
            mensagem.text += textoMensagem[count];
            count++;
        }
    }

    async void OnGUI()

    {

        if (Screen.height < 343)
        {
            altura = Screen.height / 11;
        }
        else
        {
            altura = 30;
        }

        bool voltar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + +(Screen.width / 20) * 3, Screen.width / 3, altura), "Voltar");

        if (voltar)
        {
            SceneManager.LoadScene("Login");
        }

    }


}

