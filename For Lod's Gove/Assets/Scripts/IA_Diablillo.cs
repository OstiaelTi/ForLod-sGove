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
        rb2d.freezeRotation = true;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        obstacle = GameObject.FindGameObjectWithTag("Obstacle").transform;

        
    }


    // Update is called once per frame
    void Update()
    {
        float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

        float unitari_x = (target.position.x - transform.position.x) / moduloVector;
        float unitari_y = (target.position.y - transform.position.y) / moduloVector;

        transform.position = new Vector2(
            unitari_x * moveSpeed + transform.position.x,
            unitari_y * moveSpeed + transform.position.y
            );

    }

}

