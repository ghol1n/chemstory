using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine;
using System.Threading;

public class Cadastro : MonoBehaviour
{
    [SerializeField]
    public static string usuarioButom;
    [SerializeField]
    public static string usuarioSegButom;
    [SerializeField]
    public static string senhaButom;
    [SerializeField]
    public static string apelidoButom;
    public static string invalido = "";



    public char PasswordChar { get; set; }

    public float largura;
    public float altura;
    private string _linhaDeConexao;
    private MySqlConnection conexao;

    private static GameObject gameObj;

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

        GUI.Label(new Rect(Screen.width / 3 + Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 2, altura), invalido, black);
        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, altura), "Português");

       // apelidoButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + Screen.width / 20, Screen.width / 3, altura), apelidoButom);

       // usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 2, Screen.width / 3, altura), usuarioButom);

       // senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + +(Screen.width / 20) * 3, Screen.width / 3, altura), senhaButom, "*"[0]);

       // usuarioSegButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + +(Screen.width / 20) * 4, Screen.width / 3, altura), usuarioSegButom);

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 7, Screen.width / 3, altura), "Fazer login");
        
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), "Cadastrar");
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
                        invalido = "A senha precisa ter no mínimo 8 caracteres.";
                    }
                    else
                    {
                        invalido = "Por favor aguarde.";
                        StartCoroutine(Web.Register(apelidoButom, usuarioButom, senhaButom,usuarioSegButom));
                    }
                }
                else
                {
                    invalido = "E-mail inválido.";
                }
            }
        }
        if (ingles)
        {
            SceneManager.LoadScene("CadastroEng");
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
