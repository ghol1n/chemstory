using Mgl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FimConexao : MonoBehaviour
{
    // Start is called before the first frame update
    public I18n i18n = I18n.Instance;
    public Text Botao;
    public Text Mensagem;
    void Start()
    {
        Botao.text = i18n.__("Login");
        Mensagem.text = i18n.__("Unfortunately you have been logged out because someone has logged into your account from somewhere else.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
