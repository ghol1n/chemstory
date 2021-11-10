using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{

    string myText = "Bem-vindo a Chemstory, vamos ao tutorial!";
    public Text viewer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());    
    }

    // Update is called once per frame
    IEnumerator ShowText()
    {
        int count = 0;
        while(count < myText.Length)
        {
            yield return new WaitForSeconds(0.07f);
            viewer.text += myText[count];
            count++;
        }
    }
}
