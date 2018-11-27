using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlat : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;

    public float speed;

    public float jumpForce;
    public int howManyJumps;
    private int jumpCounter;
    private bool grounded = true;
    private float h;
    private bool facingRight = false;
    public bool canMove = true;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpCounter = howManyJumps;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)&&grounded) {
            Attack();
        }
        if (canMove)
        {
            Mouvement();
        }
        else {
            rb2d.velocity = Vector2.zero;
        }
        UpdateAnimator();
        if ((facingRight && rb2d.velocity.x < 0) || (!facingRight && rb2d.velocity.x > 0f)) {
            Flip();
        }
        
    }

    void Attack() {
        anim.SetTrigger("Attack");
        canMove = false;
    }

    public void EndAttack() {
        canMove = true;
    }

    void Mouvement() {
        h = Input.GetAxisRaw("Horizontal");

        rb2d.velocity = new Vector2(h * speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0)
        {
            anim.SetTrigger("Jump");
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(new Vector2(0, jumpForce));
            jumpCounter--;
            grounded = false;
        }
    }
    void UpdateAnimator() {
        if (rb2d.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
        if (h == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else {
            anim.SetBool("isMoving", true);
        }
        anim.SetBool("Grounded", grounded);
    }
    public void Grounded() {
        jumpCounter = howManyJumps;
        grounded = true;
    }

    void Flip() {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        facingRight = !facingRight;
    }
}
