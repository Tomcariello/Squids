using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenSquidController : MonoBehaviour {
	
	//public Text CharacterText; //Reference to the Text Box

	//public GameObject DialogueBox; //Reference to the Canvas that holds the text box

	public Sprite characterSprite;

	public GameObject CutsceneTrigger; //Reference to the element that will trigger after interaction with green

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

			//If RED hasn't talked to GREEN yet
			if (GameManager.instance.talkedToGreenSquid == false) {
				//Update status variable
				GameManager.instance.talkedToGreenSquid = true;
				
				//Load string text
				string[] text = new[] {"Thank god you're here! I injured 6 of my tentacles while exploring this god-forsaken cave. I need medical attention so I can get out of here! Do you have any medicine?"};
				
				//Call dialogue box with text & sprite
				GameManager.instance.haveConversation(text, characterSprite);
			//If Red does not have the medicine & has talked to Green previously
			} else if (GameManager.instance.Inv_greenSquidMedicine == false && GameManager.instance.talkedToGreenSquid == true) {
				//Remind RED of his quest
				string[] text = new[] {"I'm weak. You're going to make me explain this again? I need medical attention so I can get out of here! Do you have any medicine?"};

				//Call dialogue box with text & sprite
				GameManager.instance.haveConversation(text, characterSprite);
			} else if (GameManager.instance.Inv_greenSquidMedicine == true && GameManager.instance.escortingGreenSquid == false) {
				//Ask for an escort out of here
				string[] text = new[] {"Thank you so much! I need to return to the shoal for further medical care. Do you think you could escort me out of here?"};
				GameManager.instance.haveConversation(text, characterSprite);
				
				//Update Green Sprite to healthy version
				gameObject.GetComponent<SpriteRenderer>().sprite = GreenHealthy;
			 	
				 //Set escorting boolean to TRUE
			 	GameManager.instance.escortingGreenSquid = true;
				
				//Change layer of GREEN to one that does not collide with RED
				gameObject.layer = 8;
				
				//Enable the Cutscene Trigger
				CutsceneTrigger.SetActive(true);
			}

		}
	}
}
