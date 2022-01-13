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
    string textoMensagem = "Insira o token enviado ao e-mail de segurança '"+result+"'. Não esqueÇa de checar a caixa de spam. =)";
    public static string token;
    public static bool valido;
    GUIStyle black = new GUIStyle();
    public static string invalido = "";
    public static string emailSeg;
    public bool jafez = false;


    public float altura;
    void Start()
    {
        //result = Login.EmailSeg.Substring(Login.EmailSeg.Length/2).PadLeft(Login.EmailSeg.Length, '*');
        black.normal.textColor = Color.black;
        black.fontSize = 16;
        valido = false;
        invalido = "";
        token = "";
        StartCoroutine(ShowText());


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
        token = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 3, Screen.width / 3, altura), token);
        bool enviar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 3, altura), "Ok");
        bool voltar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), "Voltar");
        GUI.Label(new Rect(Screen.width / 3 + Screen.width / 3 + 20, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 3, altura * 3), invalido, black);

        if (voltar)
        {
            SceneManager.LoadScene("Login");
            
        }
        if (enviar)
        {
            Debug.Log(emailSeg);
            StartCoroutine(Web.VerificarToken(token,emailSeg));
           
        }

    }


}

