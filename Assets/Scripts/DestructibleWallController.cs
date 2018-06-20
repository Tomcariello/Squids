using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWallController : MonoBehaviour {
	
	[SerializeField]
	private GameObject thisWall;

	private int numberOfHits = 0;

	void OnCollisionEnter2D (Collision2D coll) {

		//Execute if colliding with an InkBullet
		if(coll.gameObject.tag == "Falling Rock") {
			//Increment the hit counter
			numberOfHits++;

			//Destroy the falling rock that hit the wall
			Destroy(coll.gameObject);

			//Destroy the wall after all 3 rocks hit the wall
			if (numberOfHits > 2) {
				Destroy(thisWall);
			}
		}
	}
}
