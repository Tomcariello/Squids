using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 
	
	//Declare variable to track player power level
	public int playerPower = 3;

	public int jumpPower= 10;

	//Declare variables for health prefabs
	public GameObject Small_Health_Prefab;
	public GameObject Medium_Health_Prefab;
	public GameObject Large_Health_Prefab;

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

	public void standardDrop(Vector3 deathPosition) {
		float random = Random.Range(.0f, 1.0f);

		// Debug.Log("Drop random is " + random);
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
	
}
