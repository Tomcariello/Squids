using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCutsceneTriggerController : MonoBehaviour {


	//Reference to the falling rocks
	public GameObject FallingRockOne; 
	public GameObject FallingRockTwo; 
	public GameObject FallingRockThree; 
	public Sprite greenCharacterSprite;
	public Sprite redCharacterSprite;
	public GameObject GreenSquid;

	private bool cutsceneExecuted = false;

	private bool rocksAreRolling = false;

	private bool rocksStoppedRolling = false;


	void OnTriggerEnter2D (Collider2D coll) {
		
		if (coll.gameObject.tag == "Player" && cutsceneExecuted == false) {
			cutsceneExecuted = true;
			DropTheBombs();
		}
	}

	void DropTheBombs() {
		
		rocksAreRolling = true;

		StartCoroutine(rocksAreRollingCutscene());

		//Empower Red to hold the ceiling
		// GameManager.instance.canGripCeiling = (true);

	}

	IEnumerator rocksAreRollingCutscene() {
		
		//remove control from the player
		GameManager.instance.playerIsActive = false;

		//Stop GREEN from Following RED
		GameManager.instance.escortingGreenSquid = false;

		//Access the camera
		CameraControl cameraScript = Camera.main.GetComponent<CameraControl>();
		
		//Store location of the player
		Vector3 playerPostion = cameraScript.transform.position;

		//Set target of the rocks
		Vector3 target = new Vector3 (-74, 20, 0);

        //Pan to the rocks
		cameraScript.MoveCamera( target, 10f);
		yield return new WaitForSeconds(2);

		//Switch Falling Rocks to dynamic from kinematic at intervals
		FallingRockOne.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		yield return new WaitForSeconds(1);
		FallingRockTwo.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		yield return new WaitForSeconds(1);
		FallingRockThree.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

		//Pan back to the player
		cameraScript.MoveCamera( playerPostion, 12f);
		yield return new WaitForSeconds(2);

		//Load string text
		string[] text = new[] {"Look Out!!!!!"};
				
		//Call dialogue box with text & sprite
		GameManager.instance.quickMessage(text, greenCharacterSprite);

		//return control from the player
		GameManager.instance.playerIsActive = true;

		yield return new WaitForSeconds(1.25f);

		//Turn off GREEN's gravity
		GreenSquid.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

		//GREEN jumps & grips the ceiling!
		GreenSquid.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,GameManager.instance.jumpPower), ForceMode2D.Impulse);

		//Rotate GREEN's sprite face the opposite direction
		GreenSquid.transform.Rotate(0,0,180);

		yield return new WaitForSeconds(1.5f);

		//Set location for Green to move to
		Vector3 targetPosition = new Vector3 (-112.15f, 18, 0);

		//Move green to his target spot
		while (GreenSquid.transform.position != targetPosition) {
			GreenSquid.transform.position = Vector3.MoveTowards(GreenSquid.transform.position, targetPosition, 3.0f * Time.deltaTime);
		}

		yield return new WaitForSeconds(5f);

		//Load dialogue text
		text = new[] {"How the hell did you do that!?!?", "What? Explore so well?"};
		Sprite[] characterIcons = new[] {redCharacterSprite, greenCharacterSprite};
				
		//Call dialogue box with text & sprite
		GameManager.instance.haveConversation(text, characterIcons);

    }
}
