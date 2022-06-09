using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine;
using System.Threading;
using Mgl;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string[] speechTxtEng;
    public string actorName;
    public string actorNameEng;


    public LayerMask playerLayer;
    public float radius;
    bool onRadius;
    bool talking = false;
    private I18n i18n = I18n.Instance;
    public string locale;
    private DialogueControl dc;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
        locale = i18n.GetLocale();

    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onRadius && !talking && locale == "pt-BR")
        {
            talking = true;
            dc.Speech(profile, speechTxt, actorName);
        }

        if (Input.GetKeyDown(KeyCode.E) && onRadius && !talking && locale == "en-US")
        {
            talking = true;
            dc.Speech(profile, speechTxtEng, actorNameEng);
        }

    }


    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if(hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
