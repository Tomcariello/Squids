using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreensMedicineController : MonoBehaviour {

	public GameObject thisMedicine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll) {

		//Execute when encountering the player
		if(coll.gameObject.tag == "Player") {
			Debug.Log("Player touched the medicine!");

			GameManager.instance.Inv_greenSquidMedicine = true;
			Destroy(thisMedicine);
		}
	}
}
