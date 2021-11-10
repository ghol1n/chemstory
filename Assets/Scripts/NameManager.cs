using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{

    public Text Username;
    public InputField InputName;
    // Start is called before the first frame update
    void Start()
    {
        Username.text = PlayerPrefs.GetString("nama");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickSave()
    {
        PlayerPrefs.SetString("nama", InputName.text);
    }
}

