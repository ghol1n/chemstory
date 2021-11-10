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
    private string usuarioButom = "Email";
    [SerializeField]
    private string senhaButom = "Password";


    public char PasswordChar { get; set; }
    public Texture ingles;
    public float largura;
    public float altura;

    void Start()
    {
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
        GUI.Label(new Rect(Screen.width / 2 - 100, 320, 200, 30), invalido);

        bool ingles = GUI.Button(new Rect(Screen.width/2 - 100, 110, 200, 30), "English");
        bool config = GUI.Button(new Rect(Screen.width / 2 + 160, 110, 100, 30), "Configuration");

        usuarioButom = GUI.TextField(new Rect(Screen.width/2 - 100, 150, 200, 30), usuarioButom);
        senhaButom = GUI.PasswordField(new Rect(Screen.width / 2 - 100, 190, 200, 30), senhaButom, "*"[0]);

        bool logar = GUI.Button(new Rect(Screen.width / 2 - 100, 230, 200, 30), "Login");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 2 - 100, 270, 200, 30), "Register");
        if (cadastrar)
        {
            SceneManager.LoadScene("CadastroEng");
        }
        if (logar)
        {
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

