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

    public char PasswordChar { get; set; }
    public Texture ingles;
    public float largura;
    public float altura;
    //public static string ip;
    public bool temIP;
    void Start()
    {
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
        if (temIP == false)
        {
            StartCoroutine(Web.Session());
            temIP = true;
        }


        GUI.Label(new Rect(Screen.width / 2 - 100, 320, 200, 30), invalido);


        bool ingles = GUI.Button(new Rect(Screen.width / 2 - largura / 2, 110, largura, altura), "Português");
        bool config = GUI.Button(new Rect(Screen.width / 2 +160, 110, 100, 30), "Configurações");
        

        usuarioButom = GUI.TextField(new Rect(Screen.width / 2 - largura / 2, 150, largura, altura), usuarioButom);
        senhaButom = GUI.PasswordField(new Rect(Screen.width / 2 - 100, 190, 200, 30), senhaButom, "*"[0]);

        
        bool logar = GUI.Button(new Rect(Screen.width / 2 - 100, 230, 200, 30), "Logar");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 2 - 100, 270, 200, 30), "Cadastre-se");

        if (cadastrar)
        {
            SceneManager.LoadScene("Cadastro");
        }
        if (logar) {
            invalido = "Por favor aguarde.";

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
        



    }


    }

    