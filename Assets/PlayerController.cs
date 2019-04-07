using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 0.01f;
	public Rigidbody2D rb;
	
	public static int angle = 90;


	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.transform.Rotate(0,0,-10);

			// keep track of angle 
			if (angle == 0) {
				angle = 360;
			}

			angle -= 10;

		}
            
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.transform.Rotate(0,0,10);

			// keep track of angle
			if (angle == 360) {
				angle = 0;
			}

			angle += 10;

		}

	}


}
