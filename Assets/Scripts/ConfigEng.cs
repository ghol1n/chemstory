using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;

public class ConfigEng : MonoBehaviour

{

    public static string ativadotext = "Sound: ON";
    public static bool ativado = true;
    public char PasswordChar { get; set; }
    public Texture ingles;
    public float largura;
    public float altura;

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
        if (Config.ativado == false)
            ativadotext = "Sound: OFF";
        else
            ativadotext = "Sound: ON";
        // GUI.Label(new Rect(Screen.width / 2 - 100, 320, 200, 30), invalido);


        bool ingles = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6, Screen.width / 3, 30), "English");
        bool som = GUI.Button(new Rect(Screen.width / 3, Screen.width / 6 + 33, Screen.width / 3, 30), ativadotext);
        bool logar = GUI.Button(new Rect(Screen.width / 3 + Screen.width / 15, Screen.width / 6 + 75, Screen.width / 5, 30), "Back");



        if (logar)
        {
            SceneManager.LoadScene("LoginEng");

        }
        if (ingles)
        {
            SceneManager.LoadScene("Config");
        }
        if (som)
        {
            Config.ativado = !Config.ativado;
        }
    }

}

