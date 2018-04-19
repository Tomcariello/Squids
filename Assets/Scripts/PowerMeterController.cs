using System.Collections;
using System.Collections.Generic;
 using UnityEngine;

public class PowerMeterController : MonoBehaviour {
 
     void Update() {
         Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        //  pos.x = Mathf.Clamp01(pos.x);
        //  pos.y = Mathf.Clamp01(pos.y);

		
        pos.x = 1;
        pos.y = 1;
		pos.z = 1;


         transform.position = Camera.main.ViewportToWorldPoint(pos);
     }

}
