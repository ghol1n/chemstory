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
        GUI.Label(new Rect(Screen.width / 3, Screen.width / 6 + 180, Screen.width / 3, 30), invalido);
        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, 30), "Português");

        apelidoButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + 30, Screen.width / 3, 30), apelidoButom);

        usuarioButom = GUI.TextField(new Rect(Screen.width / 3, Screen.width / 6 + 60, Screen.width / 3, 30), usuarioButom);

        senhaButom = GUI.PasswordField(new Rect(Screen.width / 3, Screen.width / 6 + 90, Screen.width / 3, 30), senhaButom, "*"[0]);

        bool logar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 150, Screen.width / 3, 30), "Fazer login");
        bool cadastrar = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 120, Screen.width / 3, 30), "Cadastrar");
        if (logar)
        {
            SceneManager.LoadScene("Login");
        }
        if (cadastrar)
        {if ((String.IsNullOrEmpty(usuarioButom)) | String.IsNullOrEmpty(senhaButom) | String.IsNullOrEmpty(apelidoButom))
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
                        StartCoroutine(Web.Register(apelidoButom, usuarioButom, senhaButom));
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
