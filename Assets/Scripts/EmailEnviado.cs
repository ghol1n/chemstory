using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;
using System.Net;
using Mgl;

public class EmailEnviado : MonoBehaviour

{
    public static string result;
    public Text mensagem;
    string textoMensagem;
    public static string token;
    public static bool valido;
    GUIStyle black = new GUIStyle();
    public static string invalido = "";
    public static string emailSeg;
    public bool jafez = false;
    public I18n i18n = I18n.Instance;

    public float altura;
    void Start()
    {
        textoMensagem = i18n.__("Token Sent 3") + result + i18n.__("Token Sent 4");
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
        bool voltar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), i18n.__("Turn Back"));
        GUI.Label(new Rect(Screen.width / 3 + Screen.width / 3 + 20, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 3, altura * 3), invalido, black);

        if (voltar)
        {
            SceneManager.LoadScene("Login");

        }
        if (enviar)
        {
            Debug.Log(Cadastro.usuarioButom);
            StartCoroutine(Web.VerificarTokenEmail(token, Cadastro.usuarioButom));

        }

    }


}

