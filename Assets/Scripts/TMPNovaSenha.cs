using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TMPNovaSenha : MonoBehaviour
{

    private string theName;
    public TMP_InputField senhaTMP;
    public TMP_InputField senhaconfTMP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SENHA()
    {
        theName = senhaTMP.text;
        Cadastro.senhaButom = theName;
    }

    public void SENHACONF()
    {
        theName = senhaconfTMP.text;
        Cadastro.senhaconfButom = theName;
    }

}

