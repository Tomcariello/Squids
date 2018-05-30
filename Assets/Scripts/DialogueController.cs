using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	public Button CloseButton;
	// Use this for initialization
	void Start () {
		CloseButton.onClick.AddListener(CloseButtonClick); // listener on the start game button
	}

	void CloseButtonClick() {
		//Enable player interactivity
		GameManager.instance.playerIsActive = true;

		//Destroy the dialogue window
		Destroy(gameObject);
    }
}
