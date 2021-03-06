﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    bool isGrounded = false; //Track if the player is touching the ground
	
	public GameObject Player_Sprite; //Reference to the player Sprite
	public GameObject Player_Canvas; //Reference to the player Canvas

	public Animator Player_Anim; //Reference to the player GameObject (Parent of all player elements)
	public GameObject Ink_Bullet; //Reference to the bullet prefab

	private bool currentlyShooting = false; //track to control the bullet frequency
	public Transform InkBulletSpawn; //where to launch the bullet from

	float moveHorizontal; //Read Input to track horizontal movement
	float moveVertical;//Read Input to track vertical movement
	
	void Start () {
		Player_Anim = Player_Sprite.GetComponent<Animator>(); //Get variable link to animator
	}
	
	void Update () {
		if (GameManager.instance.playerIsActive) {

			//Read control inputs
			moveHorizontal = Input.GetAxisRaw ("Horizontal");
			moveVertical = Input.GetAxisRaw ("Vertical");

			//Shoot bullets when space bar is pressed
			if (Input.GetKey (KeyCode.Space)) {
				//If not already shooting
				if (currentlyShooting == false) {
					currentlyShooting = true;
					InkBulletSpawn = transform; //Store current position of the player
					Quaternion shotAngle = Quaternion.Euler(new Vector3(0,0,0));

					Vector3 m_Position;
					int bulletSpeed;

					//shoot left & up
					if (GameManager.instance.directionPlayerFacing == "left" && moveVertical > 0) {
						m_Position = new Vector3 (InkBulletSpawn.position.x - .65f, InkBulletSpawn.position.y, InkBulletSpawn.position.z);
						shotAngle = Quaternion.Euler(new Vector3(0,0,-45));
						bulletSpeed = -20;
					//shoot left and down
					} else if (GameManager.instance.directionPlayerFacing == "left" && moveVertical < 0) {
						m_Position = new Vector3 (InkBulletSpawn.position.x - .65f, InkBulletSpawn.position.y, InkBulletSpawn.position.z);
						shotAngle = Quaternion.Euler(new Vector3(0,0,45));
						bulletSpeed = -20;
					//shoot straight left
					} else if (GameManager.instance.directionPlayerFacing == "left") {
						m_Position = new Vector3 (InkBulletSpawn.position.x - .65f, InkBulletSpawn.position.y, InkBulletSpawn.position.z);
						shotAngle = Quaternion.Euler(new Vector3(0,0,0));
						bulletSpeed = -20;
					//shoot right and up
					} else if (GameManager.instance.directionPlayerFacing == "right" && moveVertical > 0) {
						m_Position = new Vector3 (InkBulletSpawn.position.x + .75f, InkBulletSpawn.position.y, InkBulletSpawn.position.z);
						shotAngle = Quaternion.Euler(new Vector3(0,0,45));
						bulletSpeed = 20;
					//shoot right and down
					} else if (GameManager.instance.directionPlayerFacing == "right" && moveVertical < 0) {
						m_Position = new Vector3 (InkBulletSpawn.position.x + .75f, InkBulletSpawn.position.y, InkBulletSpawn.position.z);
						shotAngle = Quaternion.Euler(new Vector3(0,0,-45));
						bulletSpeed = 20;
					//shoot straight right
					} else {
						m_Position = new Vector3 (InkBulletSpawn.position.x + .75f, InkBulletSpawn.position.y, InkBulletSpawn.position.z);
						shotAngle = Quaternion.Euler(new Vector3(0,0,0));
						bulletSpeed = 20;
					}

					// Create the Bullet from the Ink_Bullet Prefab
					var bullet = (GameObject)Instantiate (
						Ink_Bullet, //Prefab
						m_Position, //Position of player
						shotAngle);

					// Add horizontal velocity to the bullet
					bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;

					// Destroy the bullet after 2 seconds
					Destroy(bullet, 2.0f);

					//start coroutine to control shot speed
					StartCoroutine(shotLimiter());
				}
			}

			//Jump controls
			if (Input.GetKey (KeyCode.Z)) {
				if (isGrounded == true) {
					isGrounded = false;
					GetComponent<Rigidbody2D>().AddForce(new Vector2(0,GameManager.instance.jumpPower), ForceMode2D.Impulse);
				}
			}

			//move player right as per keyboard input
			if ((Input.GetKey (KeyCode.RightArrow)) || (Input.GetKey (KeyCode.D))) {
				if (isGrounded == true) {
					transform.Translate(Vector2.right * 8f * Time.deltaTime);
				} else {
					//Adjust this to keep momentum but not add any additional force laterally while in the air
					transform.Translate(Vector2.right * 4f * Time.deltaTime);
				}
			}

			//move player left as per keyboard input
			if ((Input.GetKey (KeyCode.LeftArrow)) || (Input.GetKey (KeyCode.A))) {
				if (isGrounded == true) {
					transform.Translate(-Vector2.right * 8f * Time.deltaTime);
				} else {
					//Adjust this to keep momentum but not add any additional force laterally while in the air
					transform.Translate(-Vector2.right * 4f * Time.deltaTime);
				}
			}

			if (GameManager.instance.playerCurrentPower == 0) {
				Destroy(Player_Canvas);
				SceneManager.LoadScene("MainMenu");
			}

			//Check inputs & control the sprite direction
			playerDirection();
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {

		//determine if squid is touching the ground
		if(coll.gameObject.tag == "Ground") {
			isGrounded = true;
		}

		//Control gripping ceiling
		if(coll.gameObject.tag == "Grippable_Ceiling" && GameManager.instance.canGripCeiling == true) {
			this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
			Player_Sprite.transform.Rotate(0,0,180);
		}

		//Execute if colliding with a Level 1 Enemy
		if(coll.gameObject.tag == "L1_Enemy") {
			//Register on Squids power meter
			GameManager.instance.playerCurrentPower--;

			//Apply "bounceback" effect when touching an enemy
			if (GameManager.instance.directionPlayerFacing == "left") {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(5,0), ForceMode2D.Impulse);
			} else {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-5,0), ForceMode2D.Impulse);
			}
		}  else if (coll.gameObject.tag == "Falling Rock") {
			//Kill player if hit by falling rock
			GameManager.instance.playerCurrentPower = 0;
		}
	}

	void OnCollisionStay2D (Collision2D coll) {
		//If Player jumps, release from the ceiling
		if(coll.gameObject.tag == "Grippable_Ceiling" && GameManager.instance.canGripCeiling == true) {
			if (Input.GetKey (KeyCode.Z)) {
				this.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
			}
		}
	}


	void OnCollisionExit2D (Collision2D coll) {
		//determine if the squid is not touching the ground
		if(coll.gameObject.tag == "Ground") {
			isGrounded = false;
		}

		//If released from the ceiling
		if(coll.gameObject.tag == "Grippable_Ceiling" && GameManager.instance.canGripCeiling == true) {
			this.GetComponent<Rigidbody2D>().gravityScale = 1.0f; //restore gravity
			Player_Sprite.transform.Rotate(0,0,180); //re-rotate sprite
		}
	}



	//Limit the rate of fire of the squid
	IEnumerator shotLimiter() {
		yield return new WaitForSeconds(.25f);
		currentlyShooting = false;
	}

	void playerDirection() {
		//Player moving horizontally
		if (moveHorizontal != 0) {
			Player_Anim.SetBool("movePlayer",true); //Set move animation

			//If player pushing left, set player sprite to face left
			if (moveHorizontal < 0) {
				GameManager.instance.directionPlayerFacing = "left";
				Vector3 spriteLocalscale = transform.localScale;
				spriteLocalscale.x = -1.3f;
				transform.localScale = spriteLocalscale;
			} else { //If player pushing right, set player sprite to face right
				GameManager.instance.directionPlayerFacing = "right";
				Vector3 spriteLocalscale = transform.localScale;
				spriteLocalscale.x = 1.3f;
				transform.localScale = spriteLocalscale;
			}
		} else {
			//Not moving horizontally, so set boolean value to false
			Player_Anim.SetBool("movePlayer",false);
		}

	}

}
