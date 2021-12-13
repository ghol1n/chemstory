using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading;

public class LoginEng : MonoBehaviour
{
    public static string invalido = "";

    [SerializeField]
    public static string usuarioButom = "Email";
    [SerializeField]
    public static string senhaButom = "Password";


    public char PasswordChar { get; set; }
    public Texture ingles;
    public float largura;
    public float altura;
    public bool temIP;

    void Start()
    {
        temIP = false;
        usuarioButom = "Email";
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

       /* if (temIP == false)
        {
            StartCoroutine(Web.Session());
            temIP = true;
        }*/

        GUI.Label(new Rect(Screen.width / 2 - 100, 320, 200, 30), invalido);

        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, 30), "English");
        bool config = GUI.Button(new Rect(Screen.width / 3 + Screen.width / 3 + 30, Screen.width / 6, Screen.width / 5, 30), "Configuration");

        usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + 30, Screen.width / 3, 30), usuarioButom);
        senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + 60, Screen.width / 3, 30), senhaButom, "*"[0]);

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 90, Screen.width / 3, 30), "Login");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 120, Screen.width / 3, 30), "Register");
        if (cadastrar)
        {
            SceneManager.LoadScene("CadastroEng");
        }
        if (logar)
        {
            invalido = "Please wait.";
            StartCoroutine(Web.ConectarEng(usuarioButom, senhaButom));
        }
        if (config)
        {
            SceneManager.LoadScene("ConfigEng");
        }
        if (ingles)
        {
            SceneManager.LoadScene("Login");
        }
    }
}

