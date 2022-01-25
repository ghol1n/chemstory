using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine;
using System.Threading;
using Mgl;

public class Cadastro : MonoBehaviour
{
    [SerializeField]
    public static string usuarioButom;
    [SerializeField]
    public static string usuarioSegButom;
    [SerializeField]
    public static string senhaButom;
    [SerializeField]
    public static string senhaconfButom;
    [SerializeField]
    public static string apelidoButom;
    public static string invalido = "";



    public char PasswordChar { get; set; }

    public float largura;
    public float altura;
    private string _linhaDeConexao;
    private MySqlConnection conexao;

    private static GameObject gameObj;

    private I18n i18n = I18n.Instance;
    public static string Language;


    GUIStyle black = new GUIStyle();
    void Start()
    {
        
        black.normal.textColor = Color.black;
        black.fontSize = 16;
        black.font = (Font)Resources.Load("Assets/retro_computer_personal_use.ttf");
        apelidoButom = "";
        usuarioButom = "";
        senhaButom = "";
        invalido = "";
        Login.invalido = "";
        LoginEng.invalido = "";
        CadastroEng.invalido = "";
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnGUI()
    {
        black.wordWrap = true;

        if (Screen.height < 343)
        {
            altura = Screen.height / 11;
        }
        else
        {
            altura = 30;
        }

        black.fontSize = Screen.height / 30;

        GUI.Label(new Rect(Screen.width / 3 - (Screen.width / 13), Screen.width / 4 - Screen.width / 45, Screen.width / 3, altura), (i18n.__("Nickname") + ":"), black);
        GUI.Label(new Rect(Screen.width / 3 - (Screen.width / 13), Screen.width / 3 - Screen.width / 16, Screen.width / 3, altura), (i18n.__("Email") + ":"), black);
        GUI.Label(new Rect(Screen.width / 3 - (Screen.width / 13), Screen.width / 3 - Screen.width / 60, Screen.width / 3, altura), (i18n.__("Password") + ":"), black);
        GUI.Label(new Rect(Screen.width / 3 - (Screen.width / 13), Screen.width / 2 - Screen.width / 7, Screen.width / 10, altura), (i18n.__("Security Email") + ":"), black);

        GUI.Label(new Rect(Screen.width / 3 + Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 2, altura), invalido, black);
        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, altura), i18n.__("Language"));

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 7, Screen.width / 3, altura), i18n.__("Turn Back"));
        
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), i18n.__("Register"));
        if (logar)
        {
            SceneManager.LoadScene("Login");
        }
        if (cadastrar)
        {if ((String.IsNullOrEmpty(usuarioButom)) | String.IsNullOrEmpty(senhaButom) | String.IsNullOrEmpty(apelidoButom) | String.IsNullOrEmpty(usuarioSegButom))
            {
                invalido = "Por favor preencha todos os campos.";
            }
            else
            {
                bool isOk = IsValidEmail(usuarioButom);
                if (isOk == true)
                {if (senhaButom.Length < 8)
                    {
                        invalido = "A senha precisa ter no m�nimo 8 caracteres.";
                    }
                    else
                    {
                        invalido = "Por favor aguarde.";
                        StartCoroutine(Web.Register(apelidoButom, usuarioButom, senhaButom,usuarioSegButom));
                    }
                }
                else
                {
                    invalido = "E-mail inv�lido.";
                }
            }
            Login.Language = i18n.GetLocale();
        }
        if (ingles)
        {
                if (i18n.GetLocale() == "pt-BR")
                {
                    i18n.SetLocale("en-US");
                }
                else
                {
                    i18n.SetLocale("pt-BR");
                }
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
