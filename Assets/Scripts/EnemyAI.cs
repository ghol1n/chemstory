using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;


    private RaycastHit2D rightWall;
    private RaycastHit2D leftWall;
    private RaycastHit2D rightLedge;
    private RaycastHit2D leftLedge;

    private int direction = 1; //1=direita  -1=esquerda

    [Header("Componentes")]
    public Rigidbody2D enemyRb;

    [Header("Movimento")]
    public float moveSpeed;

    [Header("Raycast")]
    public Vector2 offset;
    public LayerMask wallLayer;
    public LayerMask groundLayer;


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
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        enemyRb.velocity = new Vector2(moveSpeed * direction, enemyRb.velocity.y);


        if (direction > 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (direction < 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

    }

    /*private void CheckSurroundings()
    {
        //Parede direita
        rightWall = Physics2D.Raycast(new Vector2(transform.position.x + offset.x, transform.position.y + offset.y), Vector2.right, 0.2f, wallLayer);
        Debug.DrawRay(new Vector2(transform.position.x + offset.x, transform.position.y + offset.y), Vector2.right, Color.red);
        
        if (rightWall.collider !=null)
        {
            direction = -1;
        }
        
        
        
        //Parede esquerda
        leftWall = Physics2D.Raycast(new Vector2(transform.position.x - offset.x, transform.position.y + offset.y), Vector2.left, 0.1f, wallLayer);
        Debug.DrawRay(new Vector2(transform.position.x - offset.x, transform.position.y + offset.y), Vector2.left, Color.red);
            
        if (leftWall.collider != null)
        {
            direction = 1;  
        } 
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 7)
        {
            if (direction == 1)
            {
                direction = -1;
            } 
            else
            {
                direction = 1;
            }

        }
        
    }
}
