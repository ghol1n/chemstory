using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;
using System.Net;
using TMPro;
using System;
using System.Linq;

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
    public Texture ingles;
    public float largura;
    public float altura;
    //public static string ip;
    public bool temIP;
    GUIStyle black = new GUIStyle();

    //public TextMeshProUGUI emailinput;


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
       // usuarioButom.Select();
    }
    async void OnGUI()

    {
        /*if (temIP == false)
        {
            StartCoroutine(Web.Session());
            temIP = true;
        }*/

        if(Screen.height < 343)
        {
            altura = Screen.height / 11;
        }
        else
        {
            altura = 30;
        }
            
        
        bool ingles = GUI.Button(new Rect(Screen.width / 3 , Screen.width / 6, Screen.width / 3, altura), "Português");
        bool config = GUI.Button(new Rect(Screen.width / 3 + Screen.width / 3 + 30, Screen.width / 6, Screen.width / 5, altura), "Configurações");
        

       // usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + Screen.width /20, Screen.width / 3, altura), usuarioButom);
      //  senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20)*2, Screen.width / 3, altura), senhaButom, "*"[0]);
        
        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 3, Screen.width / 3, altura), "Logar");
        bool esqueci = GUI.Button(new Rect((Screen.width / 5) * 2, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 5, altura / 2 + altura / 8), "Esqueci a senha");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), "Cadastre-se");
                     GUI.Label(new Rect(Screen.width / 3 + Screen.width / 3 + 20, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 3, altura*3), invalido, black);
       // usuarioButom.onFocus();
        if (cadastrar)
        {
            SceneManager.LoadScene("Cadastro");
        }
        if (logar) {
            invalido = "Por favor aguarde.";
            Login.usuario = usuarioButom;
            StartCoroutine(Web.Conectar(usuarioButom, senhaButom));
        }
        if (ingles)
             {
                 SceneManager.LoadScene("LoginEng");
             }
        if (config)
        {
            SceneManager.LoadScene("Config");
        }
        if (esqueci)
        {
            
             invalido = "Por favor aguarde.";
            
            StartCoroutine(Web.GetEmailSeg(usuarioButom));
            //StartCoroutine(Web.GetSenha(usuarioButom));
            
        }
        if (foi == 1)
        {
            SenhaEnviada.emailSeg = EmailSeg;
            StartCoroutine(Web.Esqueci(EmailSeg));
            foi = 0;
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

    