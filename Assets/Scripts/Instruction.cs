using Mgl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public I18n i18n = I18n.Instance;
    
    public Text introducao;
    public Text comandos;
    public Text objetivo;
    public Text conclusao;
    public Text fase1;
    string textointroducao;
    string textocomandos;
    string textoobjetivo;
    string textoconclusao;
    string textofase1;

    // Start is called before the first frame update
    void Start()
    {
         textointroducao = i18n.__("Welcome to Chemstory, let's go to the tutorial!");
         textocomandos = i18n.__("To move the character use the arrow keys. To jump use the spacebar.");
         textoobjetivo = i18n.__("The objective is to reach the end of the level, where you will be directed to the challenge. After completing the challenge, you will have completed the level.");
         textoconclusao = i18n.__("Collect as many cherries as possible and complete the level in the shortest time for a good score! Good luck!");
         textofase1 = i18n.__("Level 1");


        StartCoroutine(ShowText());   
        
    }

    // Update is called once per frame
    IEnumerator ShowText()
    {
        int count = 0;
        while(count < textointroducao.Length)
        {
            yield return new WaitForSeconds(0.05f);
            introducao.text += textointroducao[count];
            count++;
        }
        count = 0;
        while (count < textocomandos.Length)
        {
            yield return new WaitForSeconds(0.05f);
            comandos.text += textocomandos[count];
            count++;
        }
        count = 0;
        while (count < textoobjetivo.Length)
        {
            yield return new WaitForSeconds(0.05f);
            objetivo.text += textoobjetivo[count];
            count++;
        }
        count = 0;
        while (count < textoconclusao.Length)
        {
            yield return new WaitForSeconds(0.05f);
            conclusao.text += textoconclusao[count];
            count++;
        }
        count = 0;
        while (count < textofase1.Length)
        {
            yield return new WaitForSeconds(0.05f);
            fase1.text += textofase1[count];
            count++;
        }
    }
}
