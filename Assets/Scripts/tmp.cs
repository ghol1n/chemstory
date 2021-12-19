using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tmp : MonoBehaviour
{

    private string theName;
    public TMP_InputField usuario;
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
        theName = usuario.text;
        Login.usuarioButom = theName;
    }

}

