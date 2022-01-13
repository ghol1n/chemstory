using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;
using System.Net;

public class SenhaEnviadaEng : MonoBehaviour

{
    public bool jafez = false;
    public Text mensagem;
    string textoMensagem = "Enter the token sent to the security email '" + SenhaEnviada.result + "'. don't forget to check the spam box. =)";
    public static string token = "";
    public float altura;
    public static bool valido;
    void Start()
    {
        StartCoroutine(ShowText());
        token = "";
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

        token = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 +(Screen.width / 20) * 3, Screen.width / 3, altura), token);
        bool enviar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 3, altura), "Ok");
        bool voltar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), "Back");

        if (voltar)
        {
            SceneManager.LoadScene("Login");
        }
        if (enviar)
            {
            StartCoroutine(Web.VerificarTokenEng(token, Login.EmailSeg));
        }

    }


}

