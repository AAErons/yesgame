using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    Animator anim;
    private bool facingRight;

	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = false;
    }
	
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        Attack();

        Flip(horizontal);

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

    private void Jump()
    {

    }
}
