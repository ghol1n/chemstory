using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using Mgl;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour

{
    public static int foi = 0;
    // public static string IP;
    public static string usuarioButom = "";
    public static string usuarioSegButom = "";
    public static string senhaButom = "";

    public static string invalido = "";
    public static string EmailSeg;
    public static string SenhaSeg;
    public static string usuario;
    public static string usuarioid;
    public static string token;
    public int forgotstep = 0;
    public char PasswordChar { get; set; }
    public float largura;
    public float altura;
    //public static string ip;
    public bool temIP;
    GUIStyle black = new GUIStyle();
    public I18n i18n = I18n.Instance;
    public static string Language;
    public static string InvalidoFrase;

    void Start()
    {
        foi = 0;
        black.normal.textColor = Color.black;
        black.fontSize = 16;
        black.font = (Font)Resources.Load("Assets/retro_computer_personal_use.ttf");
        temIP = false;
        usuarioButom = "";
        Cadastro.invalido = "";
        LoginEng.invalido = "";
        invalido = "";
        CadastroEng.invalido = "";
    }
    void Update()
    {

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
        black.fontSize = Screen.height / 30;


        GUI.Label(new Rect(Screen.width / 3 - (Screen.width / 13), Screen.width / 4 - Screen.width / 45, Screen.width / 3, altura), (i18n.__("Username") + ":"), black);
        GUI.Label(new Rect(Screen.width / 3 - (Screen.width / 13), Screen.width / 3 - Screen.width / 17, Screen.width / 3, altura), (i18n.__("Password") + ":"), black);

        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, altura), i18n.__("Language"));
        bool config = GUI.Button(new Rect(Screen.width / 3 + Screen.width / 3 + 30, Screen.width / 6, Screen.width / 5, altura), i18n.__("Configuration"));

        // usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + Screen.width / 20, Screen.width / 3, altura), usuarioButom);
        // senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 3, altura), senhaButom, "*"[0]);

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 3, Screen.width / 3, altura), "Login");
        bool esqueci = GUI.Button(new Rect((Screen.width / 5) * 2, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 5, altura / 2 + altura / 8), i18n.__("Forgot Password"));
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), i18n.__("Register"));

        GUI.Label(new Rect(Screen.width / 3 + Screen.width / 3 + 20, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 3, altura * 3), invalido, black);
        // usuarioButom.onFocus();
        if (cadastrar)
        {
            SceneManager.LoadScene("Cadastro");
        }
        if (logar) {
            invalido = i18n.__("Await") + "...";
            Login.usuario = usuarioButom;
            Language = i18n.GetLocale();
            StartCoroutine(Web.Conectar(usuarioButom, senhaButom));
        }
        if (ingles)
        { if (i18n.GetLocale() == "pt-BR")
            {
                i18n.SetLocale("en-US");
                invalido = null;
            }
            else
            {
                i18n.SetLocale("pt-BR");
                invalido = null;
            }
        }
        if (config)
        {
            SceneManager.LoadScene("Config");
        }
        if (esqueci)
        {
            invalido = i18n.__("Await") + "...";
            token = gerarToken(6);

            StartCoroutine(Web.GetEmailSeg(usuarioButom));
            // StartCoroutine(Web.GetSenhaEng(Login.usuarioButom));

        }
        if (Login.foi == 1)
        {
            StartCoroutine(Web.Esqueci(EmailSeg));
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

    