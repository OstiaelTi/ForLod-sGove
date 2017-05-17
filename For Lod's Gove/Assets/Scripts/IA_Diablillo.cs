using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IA_Diablillo : MonoBehaviour
{

    public float moveSpeed;
    public int life;

    public Transform target;
    public Transform obstacle;

    private bool facingRight;

    //Cross
    GameObject cross;
    Cross crossScript;
    bool crossInRange;


    //posicio inicial
    public int x, y;


    private Rigidbody2D rb2d;

    public bool isDead = false;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;

      //  cross = GameObject.FindGameObjectWithTag("Cross");
        

        target = GameObject.FindGameObjectWithTag("Player").transform;
        obstacle = GameObject.FindGameObjectWithTag("Obstacle").transform;

        facingRight = true;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == cross)
        {
            crossInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == cross)
        {
            crossInRange = false;
        }
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

       if (target.position.x < transform.position.x && facingRight)
        {
            Flip();
        }

        if (target.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }

    }

    private void Flip()
    {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
    }

    private void attack()
    {
        life -= 50;
    }

    private void Death()
    {
        //Activar animació de muerte 
        //Destroy(IA_Diablillo);

    }

}

