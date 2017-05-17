using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour
{
    public GameObject Giovanni;
    float horizontal;
    float vertical;


    public float damage;
    public float speed;
    public double distance;
    public GameObject CrossObj;

    public Transform target;

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

        target = GameObject.FindGameObjectWithTag("Player").transform;

        rb2d = GetComponent<Rigidbody2D>();
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        itsOnGiovanni = true;
        itsGoing = false;
        itsGoingUp = false;
        itsGoingRight = false;
        itsGoingLeft = false;
        itsGoingDown = false;


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

            float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

            float unitari_x = (target.position.x - transform.position.x) / moduloVector;
            float unitari_y = (target.position.y - transform.position.y + 2) / moduloVector;

            transform.position = new Vector2(
                unitari_x * speed * 2 + transform.position.x,
                unitari_y * speed * 2 + transform.position.y
                );
        }

        float positionX = Mathf.Abs(target.position.x - transform.position.x);
        float positionY = Mathf.Abs(target.position.y - transform.position.y);
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




        /*
                if (itsGoing)
                {


                    if (horizontal < 0 && vertical == 0)
                    {
                        transform.position = new Vector2(
                            -speed + transform.position.x,
                            transform.position.y
                            );
                    }
                    else if (horizontal > 0 && vertical == 0)
                    {
                        transform.position = new Vector2(
                            speed + transform.position.x,
                            transform.position.y
                            );
                    }
                    else if (horizontal == 0 && vertical < 0)
                    {
                        transform.position = new Vector2(
                            transform.position.x,
                            -speed + transform.position.y
                            );
                    }
                    else if (horizontal == 0 && vertical > 0)
                    {
                        transform.position = new Vector2(
                            transform.position.x,
                            speed + transform.position.y
                            );
                    }



                    else if (horizontal < 0 && vertical < 0)
                    {
                        transform.position = new Vector2(
                            -speed + transform.position.x,
                            -speed + transform.position.y
                            );
                    }
                    else if (horizontal > 0 && vertical > 0)
                    {
                        transform.position = new Vector2(
                            speed + transform.position.x,
                            speed + transform.position.y
                            );
                    }
                    else if (horizontal > 0 && vertical < 0)
                    {
                        transform.position = new Vector2(
                            speed + transform.position.x,
                            -speed + transform.position.y
                            );
                    }
                    else if (horizontal < 0 && vertical > 0)
                    {
                        transform.position = new Vector2(
                            -speed + transform.position.x,
                            speed + transform.position.y
                            );
                    }
                }
        */



    }
}