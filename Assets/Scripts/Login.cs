using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;
using System.Net;

public class Login : MonoBehaviour

{
   // public static string IP;
    [SerializeField]
    public static string usuarioButom = "E-mail";
    [SerializeField]
    public static string senhaButom = "Senha";

    public static string invalido = "";
    public static string usuario;
    public static string usuarioid;
    public char PasswordChar { get; set; }
    public Texture ingles;
    public float largura;
    public float altura;
    //public static string ip;
    public bool temIP;
    GUIStyle black = new GUIStyle();

    void Start()
    {
        black.normal.textColor = Color.black;
        temIP = false;
        usuarioButom = "E-mail";
        Cadastro.invalido = "";
        LoginEng.invalido = "";
        invalido = "";
        CadastroEng.invalido = "";

    }
    void Update()
    {

    }
    void OnGUI()

    {
        /*if (temIP == false)
        {
            StartCoroutine(Web.Session());
            temIP = true;
        }*/


        GUI.Label(new Rect(Screen.width / 3, Screen.width / 6 + 180, Screen.width / 3, 30), invalido, black);

        bool ingles = GUI.Button(new Rect(Screen.width / 3 , Screen.width / 6, Screen.width / 3, 30), "Português");
        bool config = GUI.Button(new Rect(Screen.width / 3 + Screen.width / 3 + 30, Screen.width / 6, Screen.width / 5, 30), "Configurações");
        

        usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + 30, Screen.width / 3, 30), usuarioButom);
        senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + 60, Screen.width / 3, 30), senhaButom, "*"[0]);
        
        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 90, Screen.width / 3, 30), "Logar");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 150, Screen.width / 3, 30), "Cadastre-se");
        if (cadastrar)
        {
            SceneManager.LoadScene("Cadastro");
        }
        if (logar) {
            invalido = "Por favor aguarde.";
            Login.usuario = usuarioButom;
            StartCoroutine(Web.Conectar(usuarioButom, senhaButom));
            Debug.Log(usuario);
            
        }
        if (ingles)
             {
                 SceneManager.LoadScene("LoginEng");
             }
        if (config)
        {
            SceneManager.LoadScene("Config");
        }


    }


    }

    