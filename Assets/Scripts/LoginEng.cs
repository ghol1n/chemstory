using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading;
using UnityEngine.EventSystems;
using System.Linq;
using Mgl;

public class LoginEng : MonoBehaviour
{
    public static int foi = 0;
    public static string invalido = "";

    [SerializeField]
    public static string usuarioButom = "";
    [SerializeField]
    public static string senhaButom = "";

    public static string token;
    public char PasswordChar { get; set; }
    public Texture ingles;
    public float largura;
    public float altura;
    public bool temIP;
    GUIStyle black = new GUIStyle();
    public I18n i18n = I18n.Instance;

    void Start()
    {
        
        i18n.SetLocale("en-US");
        Login.foi = 0;
        black.normal.textColor = Color.black;
        black.fontSize = 16;
        black.font = (Font)Resources.Load("Assets/retro_computer_personal_use.ttf");
        temIP = false;
        usuarioButom = "";
        Cadastro.invalido = "";
        Login.invalido = "";
        invalido = "";
        CadastroEng.invalido = "";
    }
    void Update()
    {
        Cadastro.invalido = "";
    }

    void OnGUI()
    {

        

        if (Screen.height < 343)
        {
            altura = Screen.height / 11;
        }
        else
        {
            altura = 30;
        }

        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, altura), i18n.__("English"));
        bool config = GUI.Button(new Rect(Screen.width / 3 + Screen.width / 3 + 30, Screen.width / 6, Screen.width / 5, altura), i18n.__("Configuration"));

       // usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + Screen.width / 20, Screen.width / 3, altura), usuarioButom);
       // senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 3, altura), senhaButom, "*"[0]);

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + +(Screen.width / 20) * 3, Screen.width / 3, altura), "Login");
        bool esqueci = GUI.Button(new Rect((Screen.width / 5) * 2, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 5, altura / 2 + altura / 8), i18n.__("Forgot Password"));
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), i18n.__("Register"));

        GUI.Label(new Rect(Screen.width / 3 + Screen.width / 3 + 20, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 3, altura * 3), invalido, black);

        if (cadastrar)
        {
            SceneManager.LoadScene("CadastroEng");
        }
        if (logar)
        {
           // Login.usuario = usuarioButom;
            invalido = "Please wait.";
            Login.usuario = Login.usuarioButom;
            StartCoroutine(Web.ConectarEng(Login.usuarioButom, Login.senhaButom));
            Debug.Log(Login.usuario);

        }
        if (config)
        {
            SceneManager.LoadScene("ConfigEng");
        }
        if (ingles)
        {
            SceneManager.LoadScene("Login");
        }
        if (esqueci)
        {
            token = gerarToken(6);
            invalido = "Wait a moment please.";

            StartCoroutine(Web.GetEmailSeg(Login.usuarioButom));
           // StartCoroutine(Web.GetSenhaEng(Login.usuarioButom));

        }
        if (Login.foi == 1)
        {
            StartCoroutine(Web.EsqueciEng(Login.EmailSeg, token));
            Login.foi = 0;
        }
    }
    public static string gerarToken(int tamanho)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new System.Random();
        var result = new string(
            Enumerable.Repeat(chars, tamanho)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }
}

