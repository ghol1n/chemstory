using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeD : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        InvokeRepeating("timeAdd", 1f, 1f);
    }

    void timeAdd()
    {
        GameControllerD1.totalTime += 1;
        GameControllerD1.instance.UpdateTimeText();
    }
}
