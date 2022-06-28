using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using Mgl;
using UnityEngine.UI;
using TMPro;

public class CadastradoSucesso : MonoBehaviour
{
    // Start is called before the first frame update
    public I18n i18n = I18n.Instance;
    public Text Botao;
    public Text Mensagem;
    void Start()
    {
        Botao.text = i18n.__("Let's play");

        Mensagem.text = i18n.__("Successfully registered!");
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
