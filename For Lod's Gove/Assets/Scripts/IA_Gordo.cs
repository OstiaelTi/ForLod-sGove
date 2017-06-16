using UnityEngine;
using System.Collections;

public class IA_Gordo : MonoBehaviour
{
    //Stats Diablillo
    public GameObject gordo;
    public float gSpeed;
    public float gLife;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriterender;
    public bool isDead = false;
    public float x, y;
    private bool beenAttacked;
    private Animator animator;

    DiablilloDead diablillodead;

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

    //posicio inicial

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
            if (gLife <= 0)
            {
                Death();
            }

            float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

            float unitari_x = (target.position.x - transform.position.x) / moduloVector;
            float unitari_y = (target.position.y - transform.position.y) / moduloVector;

            transform.position = new Vector2(
                unitari_x * gSpeed + transform.position.x,
                unitari_y * gSpeed + transform.position.y
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

        else
        {
            float moduloVector = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));

            float unitari_x = (x - transform.position.x) / moduloVector;
            float unitari_y = (y - transform.position.y) / moduloVector;

            transform.position = new Vector2(
                unitari_x * gSpeed + transform.position.x,
                unitari_y * gSpeed + transform.position.y
            );
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
            gLife -= crossStats.damage;
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
            Destroy(gordo);
        }
    }


}
