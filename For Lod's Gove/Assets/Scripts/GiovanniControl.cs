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

  


    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
 

    }

    void FixedUpdate()
    {
        transform.Translate(
            moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,
            moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 
            0f);
        
        
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

}
