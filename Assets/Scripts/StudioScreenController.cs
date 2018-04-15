using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudioScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(FadeAndAdvance()); //Call coroutine
	}
	
    IEnumerator FadeAndAdvance() {
        yield return new WaitForSecondsRealtime(3); // Wait for 3 seconds
     	SceneManager.LoadScene("MainMenu"); //Load Main Menu scene
    }
}
