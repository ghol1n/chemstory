using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine;
using System.Threading;

public class CadastroSenhaNovaEng : MonoBehaviour
{
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

    GUIStyle black = new GUIStyle();
    void Start()
    {
        black.normal.textColor = Color.black;
        black.fontSize = 16;
        black.font = (Font)Resources.Load("Assets/retro_computer_personal_use.ttf");
        apelidoButom = "";
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
        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, altura), "English");

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 5, Screen.width / 3, altura), "Cancel");

        bool AlterarSenha = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + (Screen.width / 20) * 4, Screen.width / 3, altura), "Ok");
        if (logar)
        {
            SceneManager.LoadScene("Login");
        }
        if (AlterarSenha)
        {
            if ((Cadastro.senhaButom != Cadastro.senhaconfButom))
            {
                invalido = "As senhas não são iguais.";
            }
            else
            {

                if (Cadastro.senhaButom.Length < 8)
                {
                    invalido = "A senha precisa ter no mínimo 8 caracteres.";
                }
                else
                {
                    invalido = "Por favor aguarde.";
                    StartCoroutine(Web.AlterarSenhaEng(Login.usuarioButom, Cadastro.senhaButom));
                }
            }
        }
        if (ingles)
        {
            SceneManager.LoadScene("AlterarSenha");
        }
    }


}
