using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tmpSenha : MonoBehaviour
{

    private string theName;
    public static TMP_InputField texto;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StoreName()
    {
        theName = texto.text;
        Login.senhaButom = theName;
    }

}

