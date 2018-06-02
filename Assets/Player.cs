using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    Animator anim;
    private bool facingRight;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = false;
    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        

        if (Input.GetKeyDown("space"))
            anim.SetTrigger("attack");

        if (Input.GetKeyUp("space"))
            anim.SetTrigger("stopAttack");

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
}
