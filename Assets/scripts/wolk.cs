using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolk : MonoBehaviour
{

    void Start()
    {// Объявление методов физики персонажа и его анимации
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public bool isGrounded;
    public Transform grounCheck;
    public float jumpForce = 10f;
    public LayerMask whatIsGround;
    public Rigidbody2D rd;
    public Vector2 vectormov;
    public Animator anim;
    public float speed = 10f;
    public bool Right = false;

    void Update()
    {

        walk();

        Reflect();

        if (Input.GetKeyDown("space"))
        {
            rd.AddForce(new Vector2(0, 5) * jumpForce); // Vector(x,y) 
            anim.SetBool("jump", true); // активация анимации по сценарию jump  
        }
        else
        {   
            anim.SetBool("jump", false);

        }
    }

    void walk()
    {
        Vector2 vector2 = new Vector2();
        vector2.x = Input.GetAxis("Horizontal");// Традиционный ввод (активируются по нажатию клавиш A,D)
        vectormov = vector2.normalized * speed;
        rd.MovePosition(rd.position + vectormov * Time.fixedDeltaTime);

        anim.SetFloat("move_x", Mathf.Abs(vector2.x)); // перс двигается только при нажатии на клавы перемещения A,D

    }



    void Reflect()
    {
        //метод отзеркаливания перса 
        if ((vectormov.x < 0 && !Right) || (vectormov.x > 0 && Right))
        {
            transform.localScale *= new Vector2(-1, 1);
            Right = !Right;
        }
    }
    
}

