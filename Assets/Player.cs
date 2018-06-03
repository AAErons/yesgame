using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    Animator anim;
    private bool facingRight;
    public float jumpForce;
    private bool jumped;
    private bool isFalling;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = false;
        jumped = false;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Update () {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        Attack();

        Flip(horizontal);

        if (myRigidBody.velocity.y < -0.1 && jumped)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
            jumped = false;
        }

        if (Input.GetKeyDown("space") && !jumped)
        {
            jumped = true;
            myRigidBody.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("jump");
        }else if (jumped && isFalling)
        {
            anim.SetTrigger("stopJump");
        }
    }

    private void HandleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal, myRigidBody.velocity.y);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("attack");

        if (Input.GetMouseButtonUp(0))
            anim.SetTrigger("stopAttack");
    }
}
