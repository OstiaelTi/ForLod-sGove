﻿using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour
{

	public float damage;
	public float speed;
	public double distance;

	public Transform target;

	private Rigidbody2D rb2d;

	private bool itsGoing = true;


	private const double timeDistanceEnd = 0.01;



	// Use this for initialization
	void Start()
	{

		target = GameObject.FindGameObjectWithTag("Player").transform;

		rb2d = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update()
	{



		if (!itsGoing)
		{
			float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

			float unitari_x = (target.position.x - transform.position.x) / moduloVector;
			float unitari_y = (target.position.y - transform.position.y) / moduloVector;

			transform.position = new Vector2(
				unitari_x * speed + transform.position.x,
				unitari_y * speed + transform.position.y
			);
		}


		if (itsGoing)
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			do
			{
				if (horizontal > 0)
				{
					transform.position = new Vector2(1 + 1*speed, 0);
				}

				if (horizontal < 0)
				{
					transform.position = new Vector2(-1 - 1 * speed, 0);
				}

				if (vertical > 0)
				{
					transform.position = new Vector2(0, 1 + 1 * speed);
				}

				if (vertical < 0)
				{
					transform.position = new Vector2(0, -1 - 1 * speed);
				}

				distance -= timeDistanceEnd;


			} while (distance > 0 && itsGoing);



		}

		itsGoing = false;
	}
}