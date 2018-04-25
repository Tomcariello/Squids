using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D (Collision2D coll) {

		//Execute if colliding with an InkBullet
		if(coll.gameObject.tag == "InkBullet") {
			// Debug.Log("You shot the ground!");

			//Destroy the bullet
			Destroy(coll.gameObject);
		}
	}
}
