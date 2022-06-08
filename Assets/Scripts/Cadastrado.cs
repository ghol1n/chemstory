using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using Mgl;
using UnityEngine.UI;
using TMPro;

public class Cadastrado : MonoBehaviour
{
    // Start is called before the first frame update
    public I18n i18n = I18n.Instance;
    public Text Botao;
    public Text Mensagem;
    void Start()
    {
        Botao.text = i18n.__("Let's play");

        Mensagem.text = i18n.__("Successfully registered!");
        StartCoroutine(Web.Register(Cadastro.apelidoButom, Cadastro.usuarioButom, Cadastro.senhaButom, Cadastro.usuarioSegButom));
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
