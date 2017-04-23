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
        obstacle = GameObject.FindGameObjectWithTag("Obstacle").transform;

        transform.position = new Vector2(x, y);
    }


    // Update is called once per frame
    void Update()
    {
        if (((obstacle.position.x - transform.position.x) < disToChangeDirecction && (obstacle.position.x - transform.position.x) > -disToChangeDirecction) || 
            ((obstacle.position.y - transform.position.y) < disToChangeDirecction && (obstacle.position.y - transform.position.y) > -disToChangeDirecction))
        {
            transform.position = new Vector2(
             (transform.position.x - disToChangeDirecction*moveSpeed),
             (transform.position.y - disToChangeDirecction*moveSpeed)
             );
        }
        else 
        {
            transform.position = new Vector2(
                target.position.x * moveSpeed + (1 - moveSpeed) * transform.position.x,
                target.position.y * moveSpeed + (1 - moveSpeed) * transform.position.y
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
