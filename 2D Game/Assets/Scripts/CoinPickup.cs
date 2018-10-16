using UnityEngine;
using System.Collections;


public class CoinPickup : MonoBehaviour {

    public int PointsToAdd;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.name == "pc")
            return;
        
        
        ScoreManager.AddPoints(PointsToAdd);
        Destroy(gameObject);
		
	}
}
