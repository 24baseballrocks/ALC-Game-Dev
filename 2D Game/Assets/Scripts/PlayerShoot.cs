using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Projectile;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        animator.SetBool("isShooting", false);
        Projectile = Resources.Load("Prefabs/Projectile") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            Instantiate(Projectile, FirePoint.position, FirePoint.rotation);

        if (Input.GetKey(KeyCode.M))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            animator.SetBool("isShooting", true);

        }

        else if (Input.GetKeyUp(KeyCode.M))
        {
            animator.SetBool("isShooting", false);

        }
    }
}
