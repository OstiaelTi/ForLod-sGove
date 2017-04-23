using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IA_Diablillo : MonoBehaviour
{

    public float moveSpeed;
    public int life;

    public Transform target;
    public Transform obstacle;

    public float disToChangeDirecction;


    //posicio inicial
    public int x, y;


    private Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Obsacle").transform;

        transform.position = new Vector2(x, y);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            target.position.x * moveSpeed + (1 - moveSpeed) * transform.position.x, 
            target.position.y * moveSpeed + (1 - moveSpeed) * transform.position.y
            );
        if ((-transform.position.x + obstacle.position.x < disToChangeDirecction) || (-transform.position.y + obstacle.position.y < disToChangeDirecction))
        {
            transform.position = new Vector2(
            -(target.position.x * moveSpeed + (1 - moveSpeed) * transform.position.x),
            -(target.position.y * moveSpeed + (1 - moveSpeed) * transform.position.y)
            );
        }
    }

}

/*
 transform.position = new Vector2(
    ((target.position.x / Mathf.Sqrt(Mathf.Pow(target.position.x, 2) + Mathf.Pow(target.position.y, 2))) * moveSpeed) + ((1 - moveSpeed) * (transform.position.x / Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2)))),
    ((target.position.y / Mathf.Sqrt(Mathf.Pow(target.position.x, 2) + Mathf.Pow(target.position.y, 2))) * moveSpeed) + ((1 - moveSpeed) * (transform.position.y / Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2))))
    );
*/
