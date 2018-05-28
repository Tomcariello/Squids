using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 

	//Declare Game power variables
	public int playerFullPower = 3; // player power level
	public int playerCurrentPower = 3; // player power level

	public int jumpPower= 10; //  Jump power level

	public string directionPlayerFacing; //Track the direction the player is pointing. Used for aiming bullets left/right


	//Declare Game Ability variables
	public bool canGripCeiling = false;


	//Declare inventory variables
	public bool Inv_greenSquidMedicine = false;
	


	//Declare game status variables
	public bool talkedToGreenSquid = false;
	public bool healedGreenSquid = false;
	public bool escortingGreenSquid = false;


	//Declare variables for health prefabs
	public GameObject Small_Health_Prefab;
	public GameObject Medium_Health_Prefab;
	public GameObject Large_Health_Prefab;

	//Declare variables for text interaction
	// public Text CharacterTextBox; //Reference to the Text Box to "speak" in
	public GameObject CharacterTextPanel; //Reference to the Canvas that holds the text box

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			DestroyObject(gameObject);
		}
	}

	public void resetGame() {
		playerCurrentPower = 3;
		jumpPower = 10;
	}

	public void standardDrop(Vector3 deathPosition) {
		float random = Random.Range(.0f, 1.0f);

		//Only Drop items 75% of the time
		//2/3rds of the time drop small health
		if (random < .51f) {
			Instantiate(Small_Health_Prefab, deathPosition, transform.rotation);
		//1/5th of the time drop medium health
		} else if (random < .66f) {
			Instantiate(Medium_Health_Prefab, deathPosition, transform.rotation);
		//The raminaing time drop large health
		} else if (random < .76f) {
			Instantiate(Large_Health_Prefab, deathPosition, transform.rotation);
		}
		
	}

	//Control all communication scenese
	public void haveConversation(string sayThis, Sprite characterSprite) {
		//Instantiate the dialogue box prefab
		GameObject DialogueBoxToPrint = Instantiate(CharacterTextPanel);

		//Access the TEXT element
		Text newText = DialogueBoxToPrint.GetComponentInChildren<Text>();

		//Access the SPRITE element
		SpriteRenderer newSprite = DialogueBoxToPrint.GetComponentInChildren<SpriteRenderer>();

		//Set the text
		newText.text = sayThis;

		//Set the image
		newSprite.sprite = characterSprite;
	}

	
}
