using System.Collections;

    using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using Mgl;
using UnityEngine.UI;
using TMPro;

public class EmailExistente : MonoBehaviour
{
    // Start is called before the first frame update
    public I18n i18n = I18n.Instance;
    public Text Botao;
    public Text Mensagem;
    void Start()
    {
        Botao.text = i18n.__("Turn Back");

        Mensagem.text = i18n.__("Email, Nickname or Security Email already registered.");
    }

        // Update is called once per frame
        void Update()
    {

    }
    public void GoCadastro()
    {
        SceneManager.LoadScene("Cadastro");
    }
}
