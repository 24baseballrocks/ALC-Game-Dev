using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour {


    // Player movement variables
    public int MoveSpeed;
    public float JumpHeight;
    private bool doubleJump;


    // player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    //public LayerMask deathLava;
    private bool grounded;
    //Non-stick Player 
    private float moveVelocity;
    public Animator animator;

	// Use this for initialization
	void Start () {
        //animation reset
        animator.SetBool("isWalking",false);
        animator.SetBool("isJumping", false);
	}

     void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround /*deathLava*/);
	}

    // Update is called once per frame
    void Update() {

        //this code makes the charcter jump
        if (Input.GetKeyDown (KeyCode.Space) && grounded){
            Jump();
        }
        //coublejump code
        if (grounded)
        {
            doubleJump = false;
            animator.SetBool("isJumping", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded){
            Jump();
        doubleJump = true;

    }
        ///Non-stick player
        moveVelocity = 0f;


        //code makes the character move from side to side
        if (Input.GetKey (KeyCode.D))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = MoveSpeed;
            animator.SetBool("isWalking", true);

        }

        else if(Input.GetKey (KeyCode.D)){
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey (KeyCode.A))
        {
             //GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y); 
            moveVelocity = -MoveSpeed;
            animator.SetBool("isWalking", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);


        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1.6f, 1.7f, .7f);

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1.6f, 1.7f, .7f);


    }
    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        animator.SetBool("isJumping", true);
    }
}