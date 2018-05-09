using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenSquidController : MonoBehaviour {
	
	public Text GreenTextBox; //Reference to the Text Box

	public GameObject GreenCanvas; //Reference to the Canvas that holds the text box

	public GameObject CutsceneTrigger; //Reference to the Canvas that holds the text box

	public Sprite GreenHealthy; //Reference to the Green Sprite 
	
	bool isMoving = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.escortingGreenSquid == true) {
			StartCoroutine("followRed");
		}
	}

	IEnumerator followRed () {

		if (isMoving == false) {
			isMoving = true;

			//Get RED's position
			Vector3 targetPosition = GameObject.Find("Player").transform.position;

			//Always stay 1 unit behind RED. Modulate for direction.
			if (GameManager.instance.directionPlayerFacing == "left") {
				targetPosition.x = targetPosition.x + 1;
			} else {
				targetPosition.x = targetPosition.x - 1;
			}
		
			//Follow Red. Only move if distance exceeds .5
			while(Mathf.Abs(transform.position.x - targetPosition.x) > 0.5) {
				transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5.0f * Time.deltaTime);
				
				yield return new WaitForEndOfFrame();	
			}
		}
		isMoving = false;
	}

	void OnCollisionEnter2D (Collision2D coll) {

		//Execute when encountering the player
		if(coll.gameObject.tag == "Player") {

			//If this is the first time you have talked to RED
			if (GameManager.instance.talkedToGreenSquid == false) {
				//Explain your problem
				GreenTextBox.text = "Green Squid: Thank god you're here! I injured 6 of my tentacles while exploring this god-forsaken cave. I need medical attention so I can get out of here! Do you have any medicine?";
				GreenCanvas.SetActive(true);

				//Set variable to TRUE so triggers can function
				GameManager.instance.talkedToGreenSquid = true;
			} else {  //already talked to Red
				
				//If RED has the medicine and you're not 
				if (GameManager.instance.Inv_greenSquidMedicine == true && GameManager.instance.escortingGreenSquid == false) {
					//Update Green Sprite to healthy version
					
					//Tell RED your secret
					GreenTextBox.text = "Green Squid: I need to return to the shoal for further medical care. Do you think you could escort me to the way out of here?";

					GreenCanvas.SetActive(true);
					gameObject.GetComponent<SpriteRenderer>().sprite = GreenHealthy;

					//Set escorting boolean to TRUE
					GameManager.instance.escortingGreenSquid = true;

					//Change layer of GREEN to one that does not collide with RED
					gameObject.layer = 8;

					//Enable the Cutscene Trigger
					CutsceneTrigger.SetActive(true);

				} else if (GameManager.instance.escortingGreenSquid == false) {
					//Remind RED of his quest
					GreenTextBox.text = "Green Squid: I'm weak. You're going to make me explain this again? I need medical attention so I can get out of here! Do you have any medicine?";
					GreenCanvas.SetActive(true);
				}
			}
		}
	}

	void OnCollisionExit2D (Collision2D coll) {
		//When RED leaves, remove the text box from view
		GreenTextBox.text = "Green Squid: ...";
		GreenCanvas.SetActive(false);
	}


}
