using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll) {

		//Execute if colliding with an InkBullet
		if(coll.gameObject.tag == "Ceiling" || coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Grippable_Ceiling" || coll.gameObject.tag == "Destructible_Wall") {
			// Debug.Log("You shot the ground!");

			//Destroy the bullet
			Destroy(gameObject);
		}
	}

}
