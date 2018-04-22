using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureEnemyController : MonoBehaviour {

	private int PowerLevel = 3;
	private Vector3 StartPosition;

	private bool attackPlayer = true;
	private bool isMoving = false;
	private Vector3 targetPosition;
	
	[SerializeField]
	private GameObject thisVulture;

	void Start() {
		StartPosition = transform.position;
	}


	void Update () {
		//Compute distance between Vulture & Player
		float distance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

		//If less than 10f from the player & not already attacking, attack!	
		if (distance < 10f && isMoving == false) {
			StartCoroutine("attackPattern");
		}		
	}
	IEnumerator attackPattern () {

		//If the vulture finished attacking and is not moving, return to the initial position
		if (attackPlayer == false && isMoving == false) {
			targetPosition = StartPosition;
			attackPlayer = true;
		} else if (attackPlayer == true && isMoving == false) {
			//Time to attack! Get current position of Player
			targetPosition = GameObject.Find("Player").transform.position;
			attackPlayer = false;
		}

		isMoving = true;
		//Execute the position adjustment of the vulture
		while(Mathf.Abs(transform.position.x - targetPosition.x) > 0.5) {
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5.0f * Time.deltaTime);
			
			yield return new WaitForEndOfFrame();	
		}
		isMoving = false;

	}

	void OnCollisionEnter2D (Collision2D coll) {

		//Execute if colliding with an InkBullet
		if(coll.gameObject.tag == "InkBullet") {
			Debug.Log("You shot a vulture!");

			//Destroy the bullet
			Destroy(coll.gameObject);

			//Decrease the vulture's power
			PowerLevel--;

			//If vulture is out of power, destroy it
			if (PowerLevel < 1) {
				//Drop item
				GameManager.instance.standardDrop(this.transform.position);

				//Destroy the vulture
				Destroy(thisVulture);
			}			

		}
	}
}
