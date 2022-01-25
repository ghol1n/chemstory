using Mgl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Errado : MonoBehaviour
{
    // Start is called before the first frame update
    public I18n i18n = I18n.Instance;
    public Text Botao;
    public Text Mensagem;
    void Start()
    {
        Botao.text = i18n.__("Restart Level");
        Mensagem.text = i18n.__("Wrong Answer!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
