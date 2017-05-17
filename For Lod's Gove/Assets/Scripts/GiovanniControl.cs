using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiovanniControl : MonoBehaviour
{

    public GameObject cross;
    public GameObject Camera;


    private bool itsGoing;

    public float moveSpeed;
    private float moveSpeedDash;
    private int directionH, directionV;
    public float stamina;
    public bool crossOut;


    //Booleans per controlar el moviment
    private bool moveUp;
    private bool moveDown;
    private bool moveRight;
    private bool moveLeft;

    private Rigidbody2D rb2d;
    private Vector2 movement;

    private Animator animator;
    private bool facingRight;

    public bool isDead;





    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;

        animator = GetComponent<Animator>();

        facingRight = true;
        Instantiate(Camera, new Vector3(transform.position.x, transform.position.y, -50), Quaternion.identity);

        moveSpeedDash = moveSpeed + 10;

        crossOut = false;
        isDead = false;
        moveUp = false;
        moveDown = false;
        moveRight = false;
        moveLeft = false;

       

    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        animator.SetFloat("Speed", (Mathf.Abs(horizontal) + Mathf.Abs(vertical)));



        transform.Translate(
            moveSpeed * horizontal * Time.deltaTime,
            moveSpeed * vertical * Time.deltaTime,
            0f);

        Flip(horizontal);


        //crusss
        if (/*Input.GetKey("j") && */crossOut == false)
        {
            Instantiate(cross, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            crossOut = true;
        }


        if (horizontal < 0 && vertical == 0)
        {
            moveLeft = true;
        }
        else if (horizontal > 0 && vertical == 0)
        {
            moveRight = true;
        }
        else if (horizontal == 0 && vertical < 0)
        {
            moveDown = true;
        }
        else if (horizontal == 0 && vertical > 0)
        {
            moveUp = true;
        }

        //dashhh
        if (Input.GetKey(KeyCode.Space) && stamina > 0)
        {
           

            if (moveUp)
            {
                directionV = 1;
                GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 90);
            }

            if (moveRight)
            {
                directionH = 1;
                GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            }
            if (moveLeft)
            {
                directionH = -1;
                GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            }
            if (moveDown)
            {
                directionV = -1;
                GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -90);
            }

            
            transform.Translate(
            (directionH * moveSpeedDash) * Time.deltaTime,
            (directionV * moveSpeedDash) * Time.deltaTime,
            0f);
            
            //reset
            directionH = 0;
            directionV = 0;
            moveUp = false;
            moveDown = false;
            moveRight = false;
            moveLeft = false;
            

            //stamina
            stamina--;

            //animation
            animator.SetBool("Dash", true);
        }

        else if (!Input.GetKey(KeyCode.Space) || stamina <= 0)
        {
            animator.SetBool("Dash", false);
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);

        }







            if (isDead)
        {
            Death();
        }

    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void Death()
    {
        //Activar animació de muerte 
        //posar imatge de has mort o posar directament el menú
        //anular moviment 
        OnGUI();
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, transform.position.x, transform.position.y), "estoy muertin");
    }

}
