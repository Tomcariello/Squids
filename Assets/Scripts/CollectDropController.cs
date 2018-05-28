using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDropController : MonoBehaviour {

	private string thisObjectTag;
	private int medValue = 0;

	void Start() {
		thisObjectTag = gameObject.tag;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag =="Player") {
			if (thisObjectTag == "SmallHealth") {
				medValue = 1;
			} else if(thisObjectTag == "MediumHealth") {
				medValue = 2;
			} else if(thisObjectTag == "LargeHealth") {
				medValue = 3;
			}
		}

		if (medValue > 0) {

			//Destroy the health object you collided with
			Destroy(gameObject);

			//Increase your health if not already maxed out
			if (GameManager.instance.playerCurrentPower + medValue >= GameManager.instance.playerFullPower) {
				GameManager.instance.playerCurrentPower = GameManager.instance.playerFullPower;
			} else {
				GameManager.instance.playerCurrentPower = GameManager.instance.playerCurrentPower + medValue;
			}
		}
	}
}
