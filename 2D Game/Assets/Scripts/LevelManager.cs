using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;

    private Rigidbody2D pc;

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
        pc = FindObjectOfType<Controller2D>();
		
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo(){
        //genearte deaht particle
        Instantiate(DeathParticle, pc.transform.position, pc.transform.rotation);
        //hide player
        pc.enabled = false;
        pc.GetComponent<Renderer>().enabled = false;
        //gravity reset
        GravityStore = pc.GetComponent<Rigidbody2D>().gravityScale;
        pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
        pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //point penalty
        ScoreManager.AddPoints(-PointPenaltyOnDeath);
        //debug message
        Debug.Log("Player Respawn");
        //Reswpan Delay
        yield return new WaitForSeconds(RespawnDelay);
        //Gravity Restore
        pc.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
        //Match Players transform position
        pc.transform.position = currentCheckPoint.transform.position;
        //Showplayer
    }
}
