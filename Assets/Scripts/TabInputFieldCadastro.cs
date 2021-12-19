using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TabInputFieldCadastro : MonoBehaviour
{
    public TMP_InputField Nickname; // 0
    public TMP_InputField Username; // 1
    public TMP_InputField Password; // 2
    public TMP_InputField UsernameSeg; // 3


    public int InputSelected;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
            if(Input.GetKey(KeyCode.LeftShift))
        {
            InputSelected--;
            if (InputSelected < 0) InputSelected = 3;
            SelectInputField();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelected++;
            if (InputSelected > 3) InputSelected = 0;
            SelectInputField();
        }
        void SelectInputField()
        {
            switch (InputSelected)
            {
                case 0:
                    Nickname.Select();
                    break;
                case 1:
                    Username.Select();
                    break;
                case 2:
                    Password.Select();
                    break;
                case 3:
                    UsernameSeg.Select();
                    break;
                

            }
        }
    }
    public void NicknameSelected() => InputSelected = 0;
    public void UsernameSelected() => InputSelected = 1;
    public void PasswordSelected() => InputSelected = 2;
    public void UsernameSegSelected() => InputSelected = 3;
}
