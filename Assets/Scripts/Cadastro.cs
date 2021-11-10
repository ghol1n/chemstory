using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System;
using System.Threading;

public class Cadastro : MonoBehaviour
{
    [SerializeField]
    private string usuarioButom = "E-mail";
    [SerializeField]
    private string senhaButom = "Senha";
    [SerializeField]
    private string apelidoButom = "Apelido";
    public static string invalido = "";


    private Text feedbackmsg;
    private bool emailnulo;
    private bool apelidonulo;

    public char PasswordChar { get; set; }

    public float largura;
    public float altura;
    private string _linhaDeConexao;
    private MySqlConnection conexao;

    private static GameObject gameObj;



    // Start is called before the first frame update 
    void Start()
    {
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
        GUI.Label(new Rect(Screen.width / 2 - 100, 360, 200, 30), invalido);
        bool ingles = GUI.Button(new Rect(Screen.width / 2 - largura / 2, 110, largura, altura), "Português");

        apelidoButom = GUI.TextField(new Rect(Screen.width / 2 - largura / 2, 150, largura, altura), apelidoButom);

        usuarioButom = GUI.TextField(new Rect(Screen.width / 2 - largura / 2, 190, largura, altura), usuarioButom);

        senhaButom = GUI.PasswordField(new Rect(Screen.width / 2 - 100, 230, 200, 30), senhaButom, "*"[0]);

        bool logar = GUI.Button(new Rect(Screen.width / 2 - 100, 310, 200, 30), "Fazer login");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 2 - 100, 270, 200, 30), "Cadastrar");
        if (logar)
        {
            SceneManager.LoadScene("Login");
        }
        if (cadastrar)
        {
            StartCoroutine(Web.Register(apelidoButom, usuarioButom, senhaButom));
        }
        if (ingles)
        {
            SceneManager.LoadScene("CadastroEng");
        }
    }

}
