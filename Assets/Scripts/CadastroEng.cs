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
    private string usuarioButom = "Email";
    [SerializeField]
    private string senhaButom = "Password";
    [SerializeField]
    private string apelidoButom = "Nickname";

    public char PasswordChar { get; set; }

    public float largura;
    public float altura;
    private string _linhaDeConexao;
    private MySqlConnection conexao;

    private static GameObject gameObj;




    // Start is called before the first frame update 
    void Start()
    {
        Cadastro.invalido = "";
        Login.invalido = "";
        LoginEng.invalido = "";
        invalido = "";
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 100, 360, 300, 30), invalido);
        bool portugues = GUI.Button(new Rect(Screen.width / 2 - 100, 110, 200, 30), "English");

        apelidoButom = GUI.TextField(new Rect(Screen.width / 2 - 100, 150, 200, 30), apelidoButom);

        usuarioButom = GUI.TextField(new Rect(Screen.width / 2 - 100, 190, 200, 30), usuarioButom);

        senhaButom = GUI.PasswordField(new Rect(Screen.width / 2 - 100, 230, 200, 30), senhaButom, "*"[0]);
        
        bool logar = GUI.Button(new Rect(Screen.width / 2 - 100, 310, 200, 30), "Login");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 2 - 100, 270, 200, 30), "Register");
        if (logar)
        {
            SceneManager.LoadScene("LoginEng");
        }
        if (cadastrar)
        {
            StartCoroutine(Web.RegisterEng(apelidoButom, usuarioButom, senhaButom));
        }
        if (portugues)
        {
            SceneManager.LoadScene("Cadastro");
        }
    }

}
