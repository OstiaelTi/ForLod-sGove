using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiovanniControl : MonoBehaviour
{

   

    public float moveSpeed;


//Booleans per controlar el moviment
    private bool moveUp;
    private bool moveDown;
    private bool moveRight;
    private bool moveLeft;

    private Rigidbody2D rb2d;
    private Vector2 movement;

    private  Animator animator;
    private bool facingRight;
   

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;

        animator = GetComponent<Animator>();

        facingRight = true;

    }
	
	// Update is called once per frame
	void Update () {
 

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



        /*moveUp = Input.GetKey("up");
        moveDown = Input.GetKey("down");
        moveRight = Input.GetKey("right");
        moveLeft = Input.GetKey("left");

        if (moveUp)
        {movement = new Vector2(0, moveSpeed);}
        if (moveDown)
        { movement = new Vector2(0, -moveSpeed); }
        if (moveRight)
        { movement = new Vector2(moveSpeed, 0); }
        if (moveLeft)
        { movement = new Vector2(-moveSpeed, 0); }
        

        
        rb2d.AddForce(movement);*/

    }

    private void Flip (float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
