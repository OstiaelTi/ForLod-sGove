Cross.cs
DETALLES
ACTIVIDAD
Hoy

Bernat Pont ha subido un elemento
22:37
Texto
Cross.cs
No hay actividad registrada antes del 6 de junio de 2017


﻿using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour
{
	GiovanniStats giovannistats;
	GiovanniControl giovannicontrol;


	public float damage;
	public float speed;


	private Rigidbody2D rb2d;

	private bool
	itsOnGiovanni,
	itsGoing,
	itsGoingUp,
	itsGoingRight,
	itsGoingLeft,
	itsGoingDown;





	private const double timeDistanceEnd = 0.01;



	// Use this for initialization
	void Start()
	{
		//el primer número pertany a la creu el segon és un multiplicador dels estats del Giovanni
		damage = 5 * giovannistats.damage;
		speed = 0.5f;

		rb2d = GetComponent<Rigidbody2D>();


		itsOnGiovanni = true;
		itsGoing = false;
		itsGoingUp = false;
		itsGoingRight = false;
		itsGoingLeft = false;
		itsGoingDown = false;


	}

	private void Awake()
	{
		giovannistats = GameObject.FindObjectOfType<GiovanniStats>();
		giovannicontrol = GameObject.FindObjectOfType<GiovanniControl>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!itsGoingUp && !itsGoingRight && !itsGoingLeft && !itsGoingDown)
			itsGoing = false;
		else
			itsGoing = true;


		if (!itsGoing)
		{

			float moduloVector = Mathf.Sqrt(Mathf.Pow(giovannicontrol.transform.position.x - transform.position.x, 2) + Mathf.Pow(giovannicontrol.transform.position.y - transform.position.y, 2));

			float unitari_x = (giovannicontrol.transform.position.x - transform.position.x) / moduloVector;
			float unitari_y = (giovannicontrol.transform.position.y - transform.position.y + 2) / moduloVector;


			transform.position = new Vector3(
				unitari_x * speed * 2 + transform.position.x,
				unitari_y * speed * 2 + transform.position.y, transform.position.z
			);

		}

		float positionX = Mathf.Abs(giovannicontrol.transform.position.x - transform.position.x);
		float positionY = Mathf.Abs(giovannicontrol.transform.position.y - transform.position.y);
		if (positionX <= 2.5 && positionY <= 2.5)
		{
			itsOnGiovanni = true;
			//posar animació que porta la creu el giovanni i en el controller també
		}
		else
			itsOnGiovanni = false;





		if (Input.GetKey("u") && itsOnGiovanni && !itsGoing)
			itsGoingUp = true;

		else if (Input.GetKey("k") && itsOnGiovanni && !itsGoing)
			itsGoingRight = true;

		else if (Input.GetKey("h") && itsOnGiovanni && !itsGoing)
			itsGoingLeft = true;

		else if (Input.GetKey("j") && itsOnGiovanni && !itsGoing)
			itsGoingDown = true;



		if (itsGoingUp)
		{
			transform.position = new Vector2(
				transform.position.x,
				speed + transform.position.y
			);
		}

		if (itsGoingRight)
		{
			itsGoing = true;
			transform.position = new Vector2(
				speed + transform.position.x,
				transform.position.y
			);
		}
		if (itsGoingLeft)
		{
			itsGoing = true;
			transform.position = new Vector2(
				-speed + transform.position.x,
				transform.position.y
			);
		}
		if (itsGoingDown)
		{
			itsGoing = true;
			transform.position = new Vector2(
				transform.position.x,
				-speed + transform.position.y
			);
		}



		if (!Input.GetKey("u"))
			itsGoingUp = false;


		if (!Input.GetKey("k"))
			itsGoingRight = false;

		if (!Input.GetKey("h"))
			itsGoingLeft = false;

		if (!Input.GetKey("j"))
			itsGoingDown = false;

	}
}