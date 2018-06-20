using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreensMedicineController : MonoBehaviour {

	public GameObject thisMedicine;
	void OnCollisionEnter2D (Collision2D coll) {

		//Execute when encountering the player
		if(coll.gameObject.tag == "Player") {
			GameManager.instance.Inv_greenSquidMedicine = true;
			Destroy(thisMedicine);
		}
	}
}
