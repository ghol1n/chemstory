using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TabInputFieldSENHAS : MonoBehaviour
{
    public TMP_InputField Password; // 0
    public TMP_InputField Password1; // 1


    public int InputSelected;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
            if (Input.GetKey(KeyCode.LeftShift))
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
                case 0:
                    Password.Select();
                    break;
                case 1:
                    Password1.Select();
                    break;


            }
        }
    }
    public void PasswordSelected() => InputSelected = 0;
    public void Password1Selected() => InputSelected = 1;
}
