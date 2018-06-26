using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll) {

		//Execute when encountering the player
		if(coll.gameObject.tag == "Player") {
			SceneManager.LoadScene("StudioName"); //Reset the game
		}
	}
}
