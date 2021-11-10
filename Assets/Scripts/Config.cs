using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;

public class Config : MonoBehaviour

{

    public static string ativadotext = "Som: Ativado";
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
        if (ativado == false)
            ativadotext = "Som: Desativado";
        else
            ativadotext = "Som: Ativado";
        // GUI.Label(new Rect(Screen.width / 2 - 100, 320, 200, 30), invalido);


        bool ingles = GUI.Button(new Rect(Screen.width / 2 - 100, 110, 200, 30), "Português");
        bool som = GUI.Button(new Rect(Screen.width / 2 - 100, 150, 200, 30), ativadotext);
        bool logar = GUI.Button(new Rect(Screen.width / 2 - 50, 190, 100, 30), "Voltar");



        if (logar)
        {
            SceneManager.LoadScene("Login");

        }
        if (ingles)
        {
            SceneManager.LoadScene("ConfigEng");
        }
        if (som)
        {
            ativado = !ativado;
            
        }
    }

}

