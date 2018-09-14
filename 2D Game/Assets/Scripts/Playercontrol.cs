using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour {


    // Player movement variables
    public int MoveSpeed;
    public float JumpHeight;


    // player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    //public LayerMask deathLava;
    private bool grounded;

	// Use this for initialization
	void Start () {
		
	}

     void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround /*deathLava*/);
	}

	// Update is called once per frame
	void Update () {
     //this code makes the charcter jump
        if(Input.GetKeyDown (KeyCode.Space)&& grounded){
            Jump();
        }
        //coad maes tehc haracter move from side to side
        if (Input.GetKey (KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
        if (Input.GetKey (KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y); 
        }
    }
    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
    }
}

/* if (groundCheck.position == deathLava)
    {
    Application.Quit()
    }*/
