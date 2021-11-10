using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;

public class Login : MonoBehaviour

{

    [SerializeField]
    private string usuarioButom = "E-mail";
    [SerializeField]
    private string senhaButom = "Senha";
    [SerializeField] Image buttonImage;

    public static string invalido = "";

    public char PasswordChar { get; set; }
    public Texture ingles;
    public float largura;
    public float altura;

    void Start()
    {
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
            StartCoroutine(Web.Conectar(usuarioButom, senhaButom));
            //Thread.Sleep(600);
           // invalido = "Usuário ou senha inválidos.";
            
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

    