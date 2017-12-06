using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 50f;
    public float jumpPower = 50f;
    public bool grounded;
    private bool doubleJump;
    private bool right;
    public float maxSpeed = 20f;
    private Rigidbody2D rb2d;
    private BoxCollider2D colli;
    private Vector3 hitb;
    public float dash = 50f;
    private Animator PlayerAnim;
    private Vector3 EscalaJug;
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        colli = gameObject.GetComponent<BoxCollider2D>();
        hitb = transform.localScale;
        right = true;
        PlayerAnim = GetComponent<Animator>();
        EscalaJug = transform.localScale;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            PlayerAnim.SetTrigger("Movement");
            transform.localScale = new Vector3(EscalaJug.x, EscalaJug.y, EscalaJug.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            right = false;
            PlayerAnim.SetTrigger("Movement");
            transform.localScale = new Vector3(-EscalaJug.x, EscalaJug.y, EscalaJug.z);
        }
        if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {

            PlayerAnim.SetBool("InRun", true);

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (right)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                rb2d.AddForce(Vector2.right * dash);
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                transform.localScale = new Vector3(hitb.x, hitb.y, hitb.z);
            }
            if (!right)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                rb2d.AddForce(Vector2.left * dash);
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                transform.localScale = new Vector3(hitb.x, hitb.y, hitb.z);
            }

        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            transform.localScale = new Vector3(hitb.x, hitb.y, hitb.z);
        }

        if (Input.GetButtonDown("Jump"))
        {
            
                if (grounded)
                {
                    doubleJump = true;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, maxSpeed);
                }
                else if (doubleJump)
                {
                    doubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, maxSpeed);
            }
            
        }
    }
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.95f;

        

        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * speed) * h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }
}
