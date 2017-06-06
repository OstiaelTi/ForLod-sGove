﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IA_Diablillo : MonoBehaviour
{
	//Stats Diablillo
	public GameObject diablillo;
	public float dSpeed;
	public float dLife;
	private Rigidbody2D rb2d;
	private SpriteRenderer spriterender;
	public bool isDead = false;
	public int x, y;
	private bool beenAttacked;

	//Giovanni
	public Transform target;
	GiovanniStats giovannistats;
	GiovanniControl giovannicontrol;

	public Transform obstacle;

	private bool facingRight;

	//Cross
	bool crossInRange;
	public Transform cross;
	Cross crossStats;

	//posicio inicial

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
		spriterender = GetComponent<SpriteRenderer>();

		giovannicontrol = GameObject.FindObjectOfType<GiovanniControl>();
		giovannistats = GameObject.FindObjectOfType<GiovanniStats>();
		crossStats = GameObject.FindObjectOfType<Cross>();

		target = GameObject.FindGameObjectWithTag("Player").transform;
		obstacle = GameObject.FindGameObjectWithTag("Obstacle").transform;
		cross = GameObject.FindGameObjectWithTag("Cross").transform;

		beenAttacked = false;
		facingRight = true;
	}



	// Update is called once per frame
	void Update()
	{

		if (crossContact())
		{
			isAttacked();
			if (dLife <= 0)
			{
				Death();
			}
		}

		float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

		float unitari_x = (target.position.x - transform.position.x) / moduloVector;
		float unitari_y = (target.position.y - transform.position.y) / moduloVector;

		transform.position = new Vector2(
			unitari_x * dSpeed + transform.position.x,
			unitari_y * dSpeed + transform.position.y
		);

		if (target.position.x < transform.position.x && facingRight)
		{
			Flip();
		}

		if (target.position.x > transform.position.x && !facingRight)
		{
			Flip();
		}


		attack();
	}

	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private bool crossContact()
	{

		if (Mathf.Abs(cross.position.x - transform.position.x) < 2 && Mathf.Abs(cross.position.y - transform.position.y) < 2)
		{
			return true;
		}

		else
		{
			beenAttacked = false;
			return false;
		}
	}

	private void isAttacked()
	{
		if (!beenAttacked)
		{
			dLife -= crossStats.damage;
			//spriterender.color = new Color(200f, 0f, 0f);
			beenAttacked = true;
		}
	}



	private void attack()
	{
		if (Mathf.Abs(giovannicontrol.transform.position.x - transform.position.x) < 5 && Mathf.Abs(giovannicontrol.transform.position.y - transform.position.y) < 5)
		{
			giovannistats.isDead = true;
		}
	}

	private void Death()
	{
		//Activar animació de muerte 
		Destroy(diablillo);
		print("diablo MUERTO");

	}

}
