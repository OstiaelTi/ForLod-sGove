using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour
{

    public float damage;
    public float speed;
    public double distance;

    public Transform player;

    private Rigidbody2D rb2d;

    private bool itsGoing;
    private bool moveUp = false, moveDown = false, moveRight = false, moveLeft = false,
                 shoot = false;

    private const double timeDistanceEnd = 0.01;
    


    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey("up");
        moveDown = Input.GetKey("down");
        moveRight = Input.GetKey("right");
        moveLeft = Input.GetKey("left");

        shoot = Input.GetKey("j");

        if (!itsGoing)
        {
            float itsSamePlace_X = player.position.x - transform.position.x;
            float itsSamePlace_Y = player.position.y - transform.position.y;

            do
            {
                transform.position = new Vector2(
                    player.position.x * speed + (1 - speed) * transform.position.x,
                    player.position.y * speed + (1 - speed) * transform.position.y
                );
            } while (itsSamePlace_X == 0 && itsSamePlace_Y == 0);
        }


        if (shoot && moveUp)
        {
            itsGoing = true;

            do
            {
                transform.position = new Vector2(0, 1 * speed);
                distance += -timeDistanceEnd;
            } while (shoot || distance > 0);
        }

        if (shoot && moveDown)
        {
            itsGoing = true;

            do
            {
                transform.position = new Vector2(0, -1 * speed);
                distance += -timeDistanceEnd;
            } while (shoot || distance > 0);
        }

        if (shoot && moveRight)
        {
            itsGoing = true;

            do
            {
                transform.position = new Vector2(1 * speed, 0);
                distance += -timeDistanceEnd;
            } while (shoot || distance > 0);
        }

        if (shoot && moveLeft)
        {
            itsGoing = true;

            do
            {
                transform.position = new Vector2(-1 * speed, 0);
                distance += -timeDistanceEnd;
            } while (shoot || distance > 0);
        }

        itsGoing = false;
    }
}