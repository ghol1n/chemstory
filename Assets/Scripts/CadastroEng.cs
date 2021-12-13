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
        bool portugues = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, 30), "English");

        apelidoButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + 30, Screen.width / 3, 30), apelidoButom);

        usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + 60, Screen.width / 3, 30), usuarioButom);

        senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + 90, Screen.width / 3, 30), senhaButom, "*"[0]);

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 150, Screen.width / 3, 30), "Login");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 120, Screen.width / 3, 30), "Register");
        if (logar)
        {
            SceneManager.LoadScene("LoginEng");
        }
        if (cadastrar)
        {

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
                        StartCoroutine(Web.RegisterEng(apelidoButom, usuarioButom, senhaButom));
                    }
                }
                else
                {
                    invalido = "Invalid Email.";
                }
            }
        }
        if (portugues)
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
