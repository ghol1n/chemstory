using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{

    string textointroducao = "Bem-vindo a Chemstory, vamos ao tutorial!          ";
    string textocomandos = "Para movimentar o personagem utilize as setas do teclado. Para pular utilize a barra de espaco.";
    string textoobjetivo = "O objetivo … chegar ao fim da fase, onde voc  ser¡ direcionado ao desafio. ap”s realizar o desafio voce ter¡ concluÕdo a fase.";
    string textoconclusao = "Colecione o m¡ximo de cerejas possÕvel e conclua a fase no menor tempo para uma boa pontuac√o! boa sorte!";
    string textofase1 = "Fase 1";

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
