using UnityEngine;
using System.Collections;

public class Cross : MonoBehaviour
{

    public float damage;
    public float speed;
    public double distance;

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
            float unitari_y = (target.position.y - transform.position.y) / moduloVector;

            transform.position = new Vector2(
                unitari_x * speed + transform.position.x,
                unitari_y * speed + transform.position.y
                );
        }


        if (itsGoing)
        {

            transform.position = new Vector2(
                1 * speed + transform.position.x,
                1 * speed + transform.position.y
                );
        }

        itsGoing = false;
    }
}