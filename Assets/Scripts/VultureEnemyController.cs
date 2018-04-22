using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureEnemyController : MonoBehaviour {

	private int PowerLevel = 3;
	private Vector3 StartPosition;

	private bool isAttacking = false;
	
	[SerializeField]
	private GameObject thisVulture;

	void Start() {
		StartPosition = transform.position;
	}


	void Update () {
		StartCoroutine("attackPattern");

	}
	IEnumerator attackPattern() {
		Vector3 targetPosition;

		//If the vulture is attacking, go back to start position
		if (isAttacking) {
			//Vulture finished attacking, so go back to the initial position
			targetPosition = StartPosition;
			isAttacking = false;

		} else {
			//Time to attack!
			//Get current position
			targetPosition = transform.position;

			//Static destination values (where the vulture will move to when attacking)
			float xDestination = targetPosition.x - 2f;
			float yDestination = targetPosition.y - 3f;

			//Adjust to target position to the values above
			targetPosition.x = xDestination;
			targetPosition.y = yDestination;
			isAttacking = true;
		}

		//Execute the position adjustment of the vulture
		while(Mathf.Abs(transform.position.x - targetPosition.x) > 0.5) {
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, 7.0f * Time.deltaTime);
			
			yield return new WaitForEndOfFrame();	
		}
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
