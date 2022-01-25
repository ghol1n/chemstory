using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;
using Mgl;

public class Config : MonoBehaviour

{

    public static string ativadotext = "Som: Ativado";
    public static bool ativado = true;
    public char PasswordChar { get; set; }
    
    public float largura;
    public float altura;
    private I18n i18n = I18n.Instance;
    public Text Configuracao;
    void Start()
    {
        Cadastro.invalido = "";
        LoginEng.invalido = "";
        CadastroEng.invalido = "";
    }
    void Update()
    {

    }
    void OnGUI()

    {
        Configuracao.text = i18n.__("Configuration");

        if (ativado == false)
            ativadotext = i18n.__("Sound") + ": " + i18n.__("Off");
        else
            ativadotext = i18n.__("Sound") +": "+ i18n.__("On");
        // GUI.Label(new Rect(Screen.width / 2 - 100, 320, 200, 30), invalido);


        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, 30), i18n.__("Language"));
        bool som = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 33, Screen.width / 3, 30), ativadotext);
        bool logar = GUI.Button(new Rect(Screen.width / 3 + Screen.width / 15, Screen.width / 6 + 75, Screen.width / 5, 30), i18n.__("Turn Back"));



        if (logar)
        {
            SceneManager.LoadScene("Login");

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
        if (som)
        {
            ativado = !ativado;
            
        }
    }

}

