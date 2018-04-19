using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 
	
	//Declare variable that need to be maintaind globally
	public int playerPower = 3;

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
		playerPower = 3;
	}
	
}
