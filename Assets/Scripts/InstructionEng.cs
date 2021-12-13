using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionEng : MonoBehaviour
{

    string textointroducao = "Welcome to Chemstory! Let's head to the tutorial!          ";
    string textocomandos = "Press the arrow keys to move. Press Space Bar to jump.";
    string textoobjetivo = "The goal is to reach the end of the level, where you will be taken to a challenge. Once the challenge is completed, you'll have completed the level. ";
    string textoconclusao = "Collect as much cherries as you can and complete the level as fast as you can to get good scores! Good Luck!";
    string textofase1 = "Level 1";

    public Text introducao;
    public Text comandos;
    public Text objetivo;
    public Text conclusao;
    public Text fase1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    // Update is called once per frame
    IEnumerator ShowText()
    {
        int count = 0;
        while (count < textointroducao.Length)
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
