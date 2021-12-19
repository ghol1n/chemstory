using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading;
using UnityEngine.EventSystems;

public class LoginEng : MonoBehaviour
{
    public static int foi = 0;
    public static string invalido = "";

    [SerializeField]
    public static string usuarioButom = "";
    [SerializeField]
    public static string senhaButom = "";


    public char PasswordChar { get; set; }
    public Texture ingles;
    public float largura;
    public float altura;
    public bool temIP;
    GUIStyle black = new GUIStyle();
    void Start()
    {
        black.normal.textColor = Color.black;
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

        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, altura), "English");
        bool config = GUI.Button(new Rect(Screen.width / 3 + Screen.width / 3 + 30, Screen.width / 6, Screen.width / 5, altura), "Configuration");

       // usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + Screen.width / 20, Screen.width / 3, altura), usuarioButom);
       // senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 3, altura), senhaButom, "*"[0]);

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + +(Screen.width / 20) * 3, Screen.width / 3, altura), "Login");
        bool esqueci = GUI.Button(new Rect((Screen.width / 5) * 2, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 5, altura / 2 + altura / 8), "Forgot Password");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), "Register");

        GUI.Label(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 6, Screen.width / 3, altura), invalido, black);

        if (cadastrar)
        {
            SceneManager.LoadScene("CadastroEng");
        }
        if (logar)
        {
           // Login.usuario = usuarioButom;
            invalido = "Please wait.";
            StartCoroutine(Web.ConectarEng(Login.usuarioButom, Login.senhaButom));
            Debug.Log(Login.usuarioButom);
            Debug.Log(Login.senhaButom);
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
            invalido = "Wait a moment please.";

            StartCoroutine(Web.GetEmailSegEng(Login.usuarioButom));
            StartCoroutine(Web.GetSenhaEng(Login.usuarioButom));

        }
        if (foi == 1)
        {
            StartCoroutine(Web.EsqueciEng(Login.usuarioButom, Login.SenhaSeg));
            foi = 0;
        }
    }
}

