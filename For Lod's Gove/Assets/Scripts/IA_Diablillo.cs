using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IA_Diablillo : MonoBehaviour
{

    public float moveSpeed;
    public int life;

    public Transform target;

    //posicio inicial
    public int x, y;


    private Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector2(x, y);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            target.position.x * moveSpeed + (1 - moveSpeed) * transform.position.x, 
            target.position.y * moveSpeed + (1 - moveSpeed) * transform.position.y
            );
    }

}