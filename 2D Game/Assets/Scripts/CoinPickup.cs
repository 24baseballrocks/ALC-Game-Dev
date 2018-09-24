using UnityEngine;
using System.Collections;


public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;

	// Use this for initialization
	void OnTriggerenter2D (Collider2D other) 
    {
        if (other.GetComponent<Rigidbody2D> () == null)
            return;

        ScoreManager.AddPoints(pointsToAdd);
        //Score += 

        Destroy (gameObject);

		
	}
}
