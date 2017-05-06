﻿using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour
{
    public GameObject Giovanni;
     

    public float damage;
    public float speed;
    public double distance;
    public GameObject CrossObj;

    public Transform target;

    private Rigidbody2D rb2d;

    private bool itsGoing;


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

        itsGoing = Input.GetKey("j");

        if (!itsGoing)
        {
            
            float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

            float unitari_x = (target.position.x - transform.position.x) / moduloVector;
            float unitari_y = (target.position.y - transform.position.y+2) / moduloVector;

            transform.position = new Vector2(
                unitari_x * speed*2 + transform.position.x,
                unitari_y * speed*2 + transform.position.y
                );

            float positionX = Mathf.Abs(target.position.x - transform.position.x);
            float positionY = Mathf.Abs(target.position.y - transform.position.y);

            if (positionX <= 2 && positionY <= 2)
            {
                Giovanni.GetComponent<GiovanniControl>().crossOut = false;
                Destroy(CrossObj);
               
            }
        }


        if (itsGoing)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");


            //switch s'ha de fer
            if (horizontal < 0 && vertical == 0)
            {
                transform.position = new Vector2(
                    -speed + transform.position.x,
                    transform.position.y
                    );
            }
            if (horizontal > 0 && vertical == 0)
            {
                transform.position = new Vector2(
                    speed + transform.position.x,
                    transform.position.y
                    );
            }
            if (horizontal == 0 && vertical < 0)
            {
                transform.position = new Vector2(
                    transform.position.x,
                    -speed + transform.position.y
                    );
            }
            if (horizontal == 0 && vertical > 0)
            {
                transform.position = new Vector2(
                    transform.position.x,
                    speed + transform.position.y
                    );
            }



            if (horizontal < 0 && vertical < 0)
            {
                transform.position = new Vector2(
                    -speed + transform.position.x,
                    -speed + transform.position.y
                    );
            }
            if (horizontal > 0 && vertical > 0)
            {
                transform.position = new Vector2(
                    speed + transform.position.x,
                    speed + transform.position.y
                    );
            }
            if (horizontal > 0 && vertical < 0)
            {
                transform.position = new Vector2(
                    speed + transform.position.x,
                    -speed + transform.position.y
                    );
            }
            if (horizontal < 0 && vertical > 0)
            {
                transform.position = new Vector2(
                    speed + transform.position.x,
                    -speed + transform.position.y
                    );
            }
        }

        itsGoing = false;
    }
}