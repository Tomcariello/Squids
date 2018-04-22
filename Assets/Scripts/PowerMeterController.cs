using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMeterController : MonoBehaviour {
 
    //Variables for the power meter game objects
    // public Image tentacle1;
    // public Image tentacle2;
    // public Image tentacle3;

    //Variables for the SpriteRenderer of the power meter game objects
    public GameObject tentacle1Image;
    public GameObject tentacle2Image;
    public GameObject tentacle3Image;

    private Color hasPower;
    private Color noPower;

    void Start() {

        //Set default values to represent full power & empty power slot
        hasPower = new Color32(255,255,225,255);
        noPower = new Color32(255,255,225,50);
    }

     void Update() {
         if (GameManager.instance.playerPower == 3) {
            tentacle1Image.GetComponent<Image>().color = hasPower;
            tentacle2Image.GetComponent<Image>().color = hasPower;
            tentacle3Image.GetComponent<Image>().color = hasPower;
         } else if (GameManager.instance.playerPower == 2) {
            tentacle1Image.GetComponent<Image>().color = hasPower;
            tentacle2Image.GetComponent<Image>().color = hasPower;
            tentacle3Image.GetComponent<Image>().color = noPower;
         } else if (GameManager.instance.playerPower == 1) {
            tentacle1Image.GetComponent<Image>().color = hasPower;
            tentacle2Image.GetComponent<Image>().color = noPower;
            tentacle3Image.GetComponent<Image>().color = noPower;       
         } else if (GameManager.instance.playerPower == 0) {
            tentacle1Image.GetComponent<Image>().color = noPower;
            tentacle2Image.GetComponent<Image>().color = noPower;
            tentacle3Image.GetComponent<Image>().color = noPower;         
         }
     }

}
