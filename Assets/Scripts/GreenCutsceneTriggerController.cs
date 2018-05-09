using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCutsceneTriggerController : MonoBehaviour {


	//Reference to the falling rocks
	public GameObject FallingRockOne; 
	public GameObject FallingRockTwo; 
	public GameObject FallingRockThree; 

	public GameObject GreenSquid;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D (Collider2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			DropTheBombs();
		}
	}

	void DropTheBombs() {
		//Switch Falling Rocks to dynamic from kinematic
		FallingRockOne.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		FallingRockTwo.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		FallingRockThree.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

		//Stop GREEN from Following RED
		GameManager.instance.escortingGreenSquid = false;

		//Turn off GREEN's gravity
		GreenSquid.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

		//GREEN jumps!
		GreenSquid.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,GameManager.instance.jumpPower), ForceMode2D.Impulse);

		//Rotate GREEN's sprite
		GreenSquid.transform.Rotate(0,0,180);

	}
}
