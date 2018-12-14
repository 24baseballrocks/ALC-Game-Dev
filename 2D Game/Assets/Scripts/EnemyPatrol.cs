using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    //movement variable

    public float MoveSpeed;
    public bool MoveRight;

    //wall chec
    public Transform WallCheck;

    public float WallCheckRadius;

    public LayerMask WhatIsWall;

    private bool HittingWall;

    private bool NotAtEgde;

    public Transform EdgeCheck;

    // Update is called once per frame
    void Update()
    {
        NotAtEgde = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);

        HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

        if (HittingWall || !NotAtEgde)
        {
            MoveRight = !MoveRight;
        }

        if (MoveRight)
        {
            transform.localScale = new Vector3(-.28f, .28f, 0f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(.28f, .28f, 0f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
