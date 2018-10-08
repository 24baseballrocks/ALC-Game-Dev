using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager LevelManager;

	// Use this for initialization
	void Start () {
        LevelManager = FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "pc") 
        {
            LevelManager.Respawnpc();
        }

	}
}
