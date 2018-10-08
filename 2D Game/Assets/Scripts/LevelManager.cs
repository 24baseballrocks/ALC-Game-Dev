using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;

    public Rigidbody2D pc;

    //particles

    public GameObject DeathParticle;
    public GameObject RespawnParticle;

    //Respawn Delay

    public float RespawnDelay;   

    //point Penalty on Death

    public int PointPenaltyOnDeath;

    private float GravityStore;

	// Use this for initialization
	void Start () {
        //pc = FindObjectOfType<Rigidbody2D> ();
		
	}

    public void Respawnpc()
    {
        StartCoroutine ("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo(){
        //Genearte Death Particle
        Instantiate (DeathParticle, pc.transform.position, pc.transform.rotation);
        //Hide Player
        //pc.enabled = false;
        pc.GetComponent<Renderer> ().enabled = false;
        //Gravity Reset
        GravityStore = pc.GetComponent<Rigidbody2D>().gravityScale;
        pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
        pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Point Penalty
        ScoreManager.AddPoints(-PointPenaltyOnDeath);
        //Debug Message
        Debug.Log("pc Respawn");
        //Reswpan Delay
        yield return new WaitForSeconds(RespawnDelay);
        //Gravity Restore
        pc.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
        //Match Players transform position
        pc.transform.position = currentCheckPoint.transform.position;
        //Show player
       // pc.enabled = true;
        pc.GetComponent<Renderer>().enabled = true;
        //Spawn pc
        Instantiate(RespawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}
