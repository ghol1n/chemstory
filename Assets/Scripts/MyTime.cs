using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTime : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        InvokeRepeating("timeAdd", 1f, 1f);
    }

    void timeAdd()
    {
        GameController1.totalTime += 1;
        GameController1.instance.UpdateTimeText();
    }

   
}
