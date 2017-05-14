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
    private float moveSpeedInicial;
    public float stamina;
	public bool crossOut;


	//Booleans per controlar el moviment
	private bool moveUp;
	private bool moveDown;
	private bool moveRight;
	private bool moveLeft;

	private Rigidbody2D rb2d;
	private Vector2 movement;

	private  Animator animator;
	private bool facingRight;

    public bool isDead;
    



    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;

		animator = GetComponent<Animator>();

		facingRight = true;
		Instantiate	(Camera, new Vector3(transform.position.x, transform.position.y, -50), Quaternion.identity);

        moveSpeedInicial = moveSpeed;
        moveSpeedDash = moveSpeed * 3;

        crossOut = false;
        isDead = false;
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


        //crusss
		if (Input.GetKey("j") && crossOut == false)
		{
			Instantiate (cross, new Vector2 (transform.position.x, transform.position.y + 2), Quaternion.identity);
			crossOut = true;
		}

        //dashhh
        if (Input.GetKey("k") && stamina >= 50)
        {
            moveSpeed = moveSpeedDash;
            //posar animació dash
        }
        else if (!Input.GetKey("k") && stamina < 50)
        {
            moveSpeed = moveSpeedInicial;
            //posar animació caminar normal
        }

        if (Input.GetKey ("j") || Input.GetKey ("k")) 
		{
			stamina--;
		}




        if (isDead)
        {
            Death();
        }

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

