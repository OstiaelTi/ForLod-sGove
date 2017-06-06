using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IA_Diablillo : MonoBehaviour
{
    //Stats Diablillo
    public float dSpeed;
    public float dLife;

    //Giovanni
    public Transform target;
    GiovanniStats giovannistats;


    public Transform obstacle;

    private bool facingRight;

    //Cross
    bool crossInRange;
    public Transform cross;
    Cross crossStats;

    //posicio inicial
    public int x, y;


    private Rigidbody2D rb2d;
    private SpriteRenderer spriterender;

    public bool isDead = false;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        spriterender = GetComponent<SpriteRenderer>();

        giovannistats = GameObject.FindObjectOfType<GiovanniStats>();
        crossStats = GameObject.FindObjectOfType<Cross>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        obstacle = GameObject.FindGameObjectWithTag("Obstacle").transform;
        cross = GameObject.FindGameObjectWithTag("Cross").transform;

        facingRight = true;
    }



    // Update is called once per frame
    void Update()
    {

        if (crossContact())
        {
            isAttacked();
            if (dLife <= 0)
            {
                Death();
            }
        }

        float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

        float unitari_x = (target.position.x - transform.position.x) / moduloVector;
        float unitari_y = (target.position.y - transform.position.y) / moduloVector;

        transform.position = new Vector2(
            unitari_x * dSpeed + transform.position.x,
            unitari_y * dSpeed + transform.position.y
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

    private bool crossContact()
    {
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        if (Mathf.Abs(cross.position.x - transform.position.x) < 2 && Mathf.Abs(cross.position.y - transform.position.y) < 2)
        {
            return true;
        }
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        //  PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI      PETA AQUI
        // ABANS TENIA:
       
          if (Mathf.Abs(cross.position.x) - Mathf.Abs( transform.position.x) < 2 && Mathf.Abs(cross.position.y) -  Mathf.Abs(transform.position.y) < 2)
        {
            return true;
        }
       

        //NO ENTENC RES PERQUE NO TE RES A VEURE );
        //SI DONAS AL PLAY VAN TOTS ELS DIABLILLOS LOCOS CAP AL PLAYER


        else
        {
            return false;
        }
    }

    private void isAttacked()
    {
        spriterender.color = new Color(200f, 0f, 0f);
        dLife -= crossStats.damage;
    }

    private void attack()
    {
        //animació atacar
        giovannistats.isDead = true;
    }

    private void Death()
    {
        //Activar animació de muerte 
        //Destroy(IA_Diablillo);

    }

}

