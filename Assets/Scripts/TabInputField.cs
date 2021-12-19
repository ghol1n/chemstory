using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabInputField : MonoBehaviour
{
    public TMP_InputField Username; // 0
    public TMP_InputField Password; // 1
    

    public int InputSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if(Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            InputSelected--;
            if (InputSelected < 0) InputSelected = 1;
            SelectInputField();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelected++;
            if (InputSelected > 1) InputSelected = 0;
            SelectInputField();
        }
    void SelectInputField()
        {
            switch (InputSelected)
            {
                case 0: Username.Select();
                    break;
                case 1: Password.Select();
                    break;
            }
        }
    }
    public void UsernameSelected() => InputSelected = 0;
    public void PasswordSelected() => InputSelected = 1;
}
