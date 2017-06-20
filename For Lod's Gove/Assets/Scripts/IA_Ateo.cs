using UnityEngine;
using System.Collections;

public class IA_Ateo : MonoBehaviour
{
    //Stats Diablillo
    public GameObject ateo;
    public float aSpeed;
    public float aLife;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriterender;
    public bool isDead = false;
    public float x, y;
    private bool beenAttacked;
    private Animator animator;

    //AteoDead ateodead;

    //Room
    public int roomNumber;

    RoomControllerScript controller;

    //Giovanni
    public Transform target;
    GiovanniStats giovannistats;
    GiovanniControl giovannicontrol;

    public Transform obstacle;

    private bool facingRight;

    //Cross
    bool crossInRange;
    public GameObject cross;
    Cross crossStats;

    float timetochange, move_x, move_y;

    void Awake()
    {
        controller = GameObject.FindObjectOfType<RoomControllerScript>();
        roomNumber = controller.roomNumber;
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        spriterender = GetComponent<SpriteRenderer>();
        x = transform.position.x;
        y = transform.position.y;
        move_x = Random.Range(-0.5f, 0.5f);
        move_y = Random.Range(-0.5f, 0.5f);

        giovannicontrol = GameObject.FindObjectOfType<GiovanniControl>();
        giovannistats = GameObject.FindObjectOfType<GiovanniStats>();
        animator = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        obstacle = GameObject.FindGameObjectWithTag("Obstacle").transform;

        beenAttacked = false;
        facingRight = true;
    }



    // Update is called once per frame
    void Update()
    {

        if (roomNumber == giovannicontrol.roomNumber)
        {
            timetochange++;

            if (aLife <= 0)
            {
                Death();
            }


            if (timetochange > 150)
            {
                move_x = Random.Range(-0.5f, 0.5f);
                move_y = Random.Range(-0.5f, 0.5f);
                timetochange = 0;
            }

            transform.position = new Vector2(
                move_x * aSpeed + transform.position.x,
                move_y * aSpeed + transform.position.y
            );

            if (cross)
            {
                crossStats = GameObject.FindObjectOfType<Cross>();
                Physics2D.IgnoreCollision(crossStats.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);

                if (crossContact())
                {
                    isAttacked();
                }
            }
        }


        if (target.position.x < transform.position.x && facingRight)
        {
            Flip();
        }

        if (target.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }

        attack();


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

        if (Mathf.Abs(crossStats.transform.position.x - transform.position.x) < 2 && Mathf.Abs(crossStats.transform.position.y - transform.position.y) < 2)
        {
            return true;
        }

        else
        {
            beenAttacked = false;
            return false;
        }
    }

    private void isAttacked()
    {
        if (!beenAttacked)
        {
            aLife -= crossStats.damage;
            //spriterender.color = new Color(200f, 0f, 0f);
            beenAttacked = true;
        }
    }



    private void attack()
    {
        if (Mathf.Abs(giovannicontrol.transform.position.x - transform.position.x) < 2.5 && Mathf.Abs(giovannicontrol.transform.position.y - transform.position.y) < 3)
        {
            animator.SetBool("Attack", true);
        }
        if (giovannistats.isDead)
        {
            Physics2D.IgnoreCollision(giovannicontrol.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }
    }

    private void Death()
    {
        animator.SetBool("Dead", true);

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Diablillo_Die"))
        {
            Destroy(ateo);
        }
    }


}
