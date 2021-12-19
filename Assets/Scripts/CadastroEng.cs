using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System;

public class CadastroEng : MonoBehaviour
{

    public static string invalido = "";

    private Text feedbackmsg;
    private bool emailnulo;
    private bool apelidonulo;
    [SerializeField]
    private string usuarioButom = "";
    [SerializeField]
    private string usuarioSegButom = "";
    [SerializeField]
    private string senhaButom = "";
    [SerializeField]
    private string apelidoButom = "Nickname";

    public char PasswordChar { get; set; }

    public float largura;
    public float altura;
    private string _linhaDeConexao;
    private MySqlConnection conexao;

    private static GameObject gameObj;


    GUIStyle black = new GUIStyle();
    void Start()
    {
        apelidoButom = "";
        usuarioButom = "";
        senhaButom = "";
        Cadastro.invalido = "";
        Login.invalido = "";
        LoginEng.invalido = "";
        invalido = "";
        black.normal.textColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {

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
        GUI.Label(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 6, Screen.width / 3, 30), invalido, black);
        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, altura), "English");

       // apelidoButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + Screen.width / 20, Screen.width / 3, altura), apelidoButom);

       // usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 3, altura), usuarioButom);

       // senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + +(Screen.width / 20) * 3, Screen.width / 3, altura), senhaButom, "*"[0]);

       // usuarioSegButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + +(Screen.width / 20) * 4, Screen.width / 3, altura), usuarioSegButom);

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 7, Screen.width / 3, altura), "Login");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), "Register");
        if (logar)
        {
            SceneManager.LoadScene("LoginEng");
        }
        if (cadastrar)
        {
            usuarioButom = Cadastro.usuarioButom;
            senhaButom = Cadastro.senhaButom;
            apelidoButom = Cadastro.apelidoButom;
            usuarioSegButom = Cadastro.usuarioSegButom;
            if ((String.IsNullOrEmpty(usuarioButom)) | String.IsNullOrEmpty(senhaButom) | String.IsNullOrEmpty(apelidoButom))
            {
                invalido = "Please fill out all fields.";
            }
            else
            {
                bool isOk = IsValidEmail(usuarioButom);
                if (isOk == true)
                {
                    if (senhaButom.Length < 8)
                    {
                        invalido = "The password must be at least 8 characters long.";
                    }
                    else
                    {
                        invalido = "Please wait.";
                        StartCoroutine(Web.RegisterEng(apelidoButom, usuarioButom, senhaButom, usuarioSegButom));
                    }
                }
                else
                {
                    invalido = "Invalid Email.";
                }
            }
        }
        if (ingles)
        {
            SceneManager.LoadScene("Cadastro");
        }
    }

    static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
