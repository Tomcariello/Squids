using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	private int conversationTracker = 0;

	public Button CloseButton;

	public Button NextButton;

	// Use this for initialization
	void Start () {
		CloseButton.onClick.AddListener(CloseButtonClick); // listener on the Close button
		NextButton.onClick.AddListener(NextButtonClick); // listener on the Next button

		controlDIalogueButon();
	}

	void CloseButtonClick() {
		//Enable player interactivity
		GameManager.instance.playerIsActive = true;

		//Destroy the dialogue window
		Destroy(gameObject);
    }

	void NextButtonClick() {
		//Advance conversation tracker to next statement
		conversationTracker++;

		//Access the Character Text Box element
		Text characterTextBox = this.GetComponentInChildren<Text>();

		//Set the text to what was passed to this function
		characterTextBox.text = GameManager.instance.textForConversations[conversationTracker];

		//Access the gameobject which holds the character image in the instantiated object
		GameObject characterDialogueImage = GameObject.Find("CharacterDialogueImage");

		//Acess the image component specifically
		Image newSprite = characterDialogueImage.GetComponentInChildren<Image>();

		//Set the image to what was passed to this function
		newSprite.sprite = GameManager.instance.characterSpritesForConversations[conversationTracker];

		controlDIalogueButon();
    }

	void controlDIalogueButon() {

		//If the tracker is not equal to the length of the array, the character(s) have more to say
		if (GameManager.instance.textForConversations.Length > conversationTracker + 1) {
			NextButton.gameObject.SetActive(true);
		} else {
			//This conversation is OVER!
			NextButton.gameObject.SetActive(false);
			CloseButton.gameObject.SetActive(true);
		}
	}
}
