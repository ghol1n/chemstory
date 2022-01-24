using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TMPCadastro : MonoBehaviour
{

    private string theName;
    public TMP_InputField apelidoTMP;
    public TMP_InputField emailTMP;
    public TMP_InputField senhaTMP;
    public TMP_InputField emailSegTMP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void APELIDO()
    {
        theName = apelidoTMP.text;
        Cadastro.apelidoButom = theName;
    }
    public void EMAIL()
    {
        theName = emailTMP.text;
        Cadastro.usuarioButom = theName;
    }
    public void SENHA()
    {
        theName = senhaTMP.text;
        Cadastro.senhaButom = theName;
    }

    public void EMAILSEG()
    {
        theName = emailSegTMP.text;
        Cadastro.usuarioSegButom = theName;
    }

}

