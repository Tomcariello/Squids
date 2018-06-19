using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCutsceneTriggerController : MonoBehaviour {


	//Reference to the falling rocks
	public GameObject FallingRockOne; 
	public GameObject FallingRockTwo; 
	public GameObject FallingRockThree; 
	public Sprite characterSprite;
	public GameObject GreenSquid;

	private bool cutsceneExecuted = false;


	void OnTriggerEnter2D (Collider2D coll) {
		
		if (coll.gameObject.tag == "Player" && cutsceneExecuted == false) {
			cutsceneExecuted = true;
			DropTheBombs();
		}
	}

	void DropTheBombs() {
		//Switch Falling Rocks to dynamic from kinematic
		FallingRockOne.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		FallingRockTwo.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		FallingRockThree.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

		//remove control from the player
		GameManager.instance.playerIsActive = false;

		//Letterbox the screen
		//
		//Pending
		//

		StartCoroutine(cameraCutscene());

		//Stop GREEN from Following RED
		GameManager.instance.escortingGreenSquid = false;

		//Turn off GREEN's gravity
		GreenSquid.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

		//GREEN jumps!
		GreenSquid.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,GameManager.instance.jumpPower), ForceMode2D.Impulse);

		//Rotate GREEN's sprite
		GreenSquid.transform.Rotate(0,0,180);

		//Empower Red to hold the ceiling
		GameManager.instance.canGripCeiling = (true);

	}

	IEnumerator cameraCutscene()
    {
		//Access the camera
		CameraControl cameraScript = Camera.main.GetComponent<CameraControl>();
		
		//Store location of the player
		Vector3 playerPostion = cameraScript.transform.position;

		//Set target of the rocks
		Vector3 target = new Vector3 (-74, 20, 0);

        //Pan to the rocks
		cameraScript.MoveCamera( target, 10f);
		yield return new WaitForSeconds(2);

		//Pan back to the player
		cameraScript.MoveCamera( playerPostion, 10f);
		yield return new WaitForSeconds(2);

		//Load string text
		string[] text = new[] {"JUMP!!!!!"};
				
		//Call dialogue box with text & sprite
		GameManager.instance.quickMessage(text, characterSprite);

		//return control from the player
		GameManager.instance.playerIsActive = true;
    }
}
