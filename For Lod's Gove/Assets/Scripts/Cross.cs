
﻿using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour
{
    public GameObject cross;
	GiovanniStats giovannistats;
	GiovanniControl giovannicontrol;
    IA_Diablillo diablillo;

	public float damage;
	public float speed;


	private Rigidbody2D rb2d;

    public bool
    itsOnGiovanni,
    itsGoing;

    private bool
	itsGoingUp,
	itsGoingRight,
	itsGoingLeft,
	itsGoingDown,
	delay;





	private const double timeDistanceEnd = 0.01;



	// Use this for initialization
	void Start()
	{
		//el primer número pertany a la creu el segon és un multiplicador dels estats del Giovanni
		damage = 5 * giovannistats.damage;
		speed = 0.5f;

		rb2d = GetComponent<Rigidbody2D>();
        diablillo = GameObject.FindObjectOfType<IA_Diablillo>();

        itsOnGiovanni = true;
		itsGoing = false;
		itsGoingUp = false;
		itsGoingRight = false;
		itsGoingLeft = false;
		itsGoingDown = false;
		delay = false;

        
        Physics2D.IgnoreCollision(giovannicontrol.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        

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
        {
            itsGoing = false;
        }
        else
            itsGoing = true;


		if (!itsGoing || giovannicontrol.currentFe <= 0)
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

		if (positionX <= 2.1 && positionY <= 2.1)
		{
			itsOnGiovanni = true;
            
			//posar animació que porta la creu el giovanni i en el controller també
		}
		else
			itsOnGiovanni = false;

		if (giovannicontrol.currentFe <= 0 && !delay){
			delay = true;
			giovannicontrol.currentFe = -100;
		}

		if (giovannicontrol.currentFe > 0)
			delay = false;



        if (itsGoing && giovannicontrol.currentFe > 0)
            giovannicontrol.LoseFe();


        if (itsOnGiovanni && giovannicontrol.currentFe < giovannicontrol.maxFe)
            giovannicontrol.AddFe();




		if (Input.GetKey("u") && itsOnGiovanni && !itsGoing && giovannicontrol.currentFe > 50)
			itsGoingUp = true;

		else if (Input.GetKey("k") && itsOnGiovanni && !itsGoing && giovannicontrol.currentFe > 50)
			itsGoingRight = true;

		else if (Input.GetKey("h") && itsOnGiovanni && !itsGoing && giovannicontrol.currentFe > 50)
			itsGoingLeft = true;

		else if (Input.GetKey("j") && itsOnGiovanni && !itsGoing && giovannicontrol.currentFe > 50)
			itsGoingDown = true;




		if (itsGoingUp && giovannicontrol.currentFe > 0)
		{
			itsGoing = true;
			transform.position = new Vector2(
				transform.position.x,
				speed + transform.position.y
			);
		}

		if (itsGoingRight && giovannicontrol.currentFe > 0)
		{
			itsGoing = true;
			transform.position = new Vector2(
				speed + transform.position.x,
				transform.position.y
			);
		}
		if (itsGoingLeft && giovannicontrol.currentFe > 0 )
		{
			itsGoing = true;
			transform.position = new Vector2(
				 transform.position.x - speed,
				transform.position.y
			);
		}
		if (itsGoingDown && giovannicontrol.currentFe > 0)
		{
			itsGoing = true;
			transform.position = new Vector2(
				transform.position.x,
				 transform.position.y - speed
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


        if(itsOnGiovanni && !itsGoing)
            deleteCross();

    }

    void deleteCross()
    {
        giovannicontrol.crossOut = false;
        if(!giovannicontrol.crossOut)
            Destroy(cross);
    }
}