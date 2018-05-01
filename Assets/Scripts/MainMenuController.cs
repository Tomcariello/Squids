using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Button startGameButton; //Link to the start game button

	// Use this for initialization
	void Start () {
		startGameButton.onClick.AddListener(StartGameClick); // listener on the start game button
	}
	
	//Click listener for the Start Game Button
    void StartGameClick() {
		GameManager.instance.resetGame();
		SceneManager.LoadScene("Gameplay"); //load the Gameplay scene
    }
	
}
