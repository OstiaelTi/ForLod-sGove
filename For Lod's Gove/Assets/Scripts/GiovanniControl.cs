using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiovanniControl : MonoBehaviour
{
	private GiovanniStats Stats;

	public GameObject Camera;
	public GameObject me;
	public GameObject cross;
	private bool itsGoing;


	private float moveSpeedDash;
	private int directionH, directionV;

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

	//enemie


	// Use this for initialization
	void Start()
	{
		Stats = GameObject.FindObjectOfType<GiovanniStats>();


		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;

		animator = GetComponent<Animator>();

		facingRight = true;
		Instantiate(Camera, new Vector3(transform.position.x, transform.position.y, -50), Quaternion.identity);

		moveSpeedDash = Stats.moveSpeed + 10;


		crossOut = true;
		//crossOut = false;

		moveUp = false;
		moveDown = false;
		moveRight = false;
		moveLeft = false;



	}

	// Update is called once per frame
	void Awake()
	{
		Instantiate(cross, new Vector2(transform.position.x, transform.position.y+2), Quaternion.identity);

	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");


		animator.SetFloat("Speed", (Mathf.Abs(horizontal) + Mathf.Abs(vertical)));



		transform.Translate(
			Stats.moveSpeed * horizontal * Time.deltaTime,
			Stats.moveSpeed * vertical * Time.deltaTime,
			0f);

		Flip(horizontal);


		//crusss
		if (/*Input.GetKey("j") && */crossOut == false)
		{

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
		if (Input.GetKey(KeyCode.Space) && Stats.fe > 0)
		{


			if (moveUp)
			{
				directionV = 1;

			}

			if (moveRight)
			{
				directionH = 1;

			}
			if (moveLeft)
			{
				directionH = -1;

			}
			if (moveDown)
			{
				directionV = -1;

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
			Stats.fe--;

			//animation
			animator.SetBool("Dash", true); //canviar animació dash
		}

		else if (!Input.GetKey(KeyCode.Space) || Stats.fe <= 0)
		{
			animator.SetBool("Dash", false);//canviar animació
			GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);

		}


		isDeath(); //pobre Giovanni );
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


	void isDeath()
	{
		if (Stats.isDead)
		{
            
            //transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            animator.SetBool("Dead", true);//Activar animació de muerte 
            //posar imatge de has mort o posar directament el menú
            Stats.moveSpeed = 0; //anular moviment


            print("muertin");
			//Destroy(me);
		}
	}


}