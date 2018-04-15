using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

     bool isGrounded = false; //Track if the player is touching the ground

	public GameObject Ink_Bullet; //Reference to the bullet prefab
	private bool currentlyShooting = false; //track to control the bullet frequency
	public Transform InkBulletSpawn; //where to launch the bullet from

	// Use this for initialization
	void Start () {
	}
	
	void Update () {
		
		//Shoot bullets when space bar is clicked
		if (Input.GetKey (KeyCode.Space)) {
			//If not already shooting
			if (currentlyShooting == false) {
				currentlyShooting = true;
				InkBulletSpawn = transform; //Store current position of the player

				// Create the Bullet from the Ink_Bullet Prefab
				var bullet = (GameObject)Instantiate (
					Ink_Bullet, //Prefab
					InkBulletSpawn.position, //Position of player
					InkBulletSpawn.rotation); //Rotation of player. Probably unnecessary on a 2D plane.

				// Add horizontal velocity to the bullet
				bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 6;

				// Destroy the bullet after 2 seconds
				Destroy(bullet, 2.0f);

				//start coroutine to control shot speed
				StartCoroutine(shotLimiter());
			}
		}


		//Jump controls
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (isGrounded == true) {
				transform.Translate(Vector2.up * 150f * Time.deltaTime);
			}
		}

		//move player right as per keyboard input
		if ((Input.GetKey (KeyCode.RightArrow)) || (Input.GetKey (KeyCode.D))) {
			if (isGrounded == true) {
				transform.Translate(Vector2.right * 10f * Time.deltaTime);
			} else {
				//Adjust this to keep momentum but not add any additional force laterally while in the air
				transform.Translate(Vector2.right * 10f * Time.deltaTime);
			}
		}

		//move player left as per keyboard input
		if ((Input.GetKey (KeyCode.LeftArrow)) || (Input.GetKey (KeyCode.A))) {
			if (isGrounded == true) {
				transform.Translate(-Vector2.right * 10f * Time.deltaTime);
			} else {
				//Adjust this to keep momentum but not add any additional force laterally while in the air
				transform.Translate(-Vector2.right * 10f * Time.deltaTime);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		//if bomb hits the barrel
		if(coll.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	void OnCollisionExit2D (Collision2D coll) {
		//if bomb hits the barrel
		if(coll.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}

	IEnumerator shotLimiter() {
		yield return new WaitForSeconds(1);
		currentlyShooting = false;
	}

}
