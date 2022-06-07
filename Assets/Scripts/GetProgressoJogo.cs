using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetProgressoJogo : MonoBehaviour
{
    public static int numFase;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Web.GetProgresso(Login.usuario));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
