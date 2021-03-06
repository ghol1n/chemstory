using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D rig;
    public float JumpForce;

    public bool isJumping;
    //public bool doubleJump;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Vector3 movment = new Vector3(Input.GetAxis("Horizontal"),0f,0f); 
        //transform.position += movment * Time.deltaTime * Speed;
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (movement == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                //doubleJump = true;
                isJumping = true;
                anim.SetBool("jump", true);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            
        if (collision.gameObject.layer == 8)
           // if (Math.Abs(collision.contacts[0].normal.y) < 0.5f)
            {
                isJumping = false;
                anim.SetBool("jump", false);
            }
        if (collision.gameObject.tag == "spike1")
            {
            StartCoroutine(Web.Cookie(Login.usuarioButom, Login.token));
            Debug.Log("Tocou o espinho");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Tocou inimigo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

        
       /* void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer != 8)
            {
                isJumping = true;
            }
        }*/
    


