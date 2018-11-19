﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Speed;
    public float TimeOut;
    public GameObject pc;
    public GameObject EnemyDeath;
    public GameObject ProjectileParticle;
    public int PointsForKill;

	// Use this for initialization
	void Start () {
        pc = GameObject.Find("PC");

        EnemyDeath = Resources.Load("Prefabs/Death P") as GameObject;

         ProjectileParticle = Resources.Load("Prefabs/Respawn P") as GameObject;

         if (pc.transform.localScale.x < 0)
            Speed = -Speed;


        Destroy(gameObject, TimeOut);
	}
	
	// Update is called once per frame
    void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
       
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.AddPoints(PointsForKill);
        }

    }

        void OnCollisionEnter2D(Collision2D other)
        {
            Instantiate(ProjectileParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}