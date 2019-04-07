using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSmallController : MonoBehaviour {

	public Rigidbody2D rb;
	
	public float speed = 0.01f;
 	Vector2 dest = Vector2.zero;

	int x, y;
	Vector2 newPos;
	
	// Update is called once per frame
	void FixedUpdate () {
		
		MoveScene();

		// calculation a new destination from current position
		dest = (Vector2)transform.position + new Vector2(x,y);
		
		// tell unity to move sprite to new location
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		rb.MovePosition(p);

		// wrap cloud	
		if (gameObject.transform.position.x < -15) {
			gameObject.transform.position = new Vector2(15.0f, gameObject.transform.position.y);
		}
		if (gameObject.transform.position.x > 15) {
			gameObject.transform.position = new Vector2(-15.0f, gameObject.transform.position.y);
		}
		if (gameObject.transform.position.y < -21) {
			gameObject.transform.position = new Vector2(gameObject.transform.position.x, 21.0f);
		}
		if (gameObject.transform.position.y > 21) {
			gameObject.transform.position = new Vector2(gameObject.transform.position.x, -21.0f);
		}	
		//Debug.Log(Time.time + "> little cloud is " + angle + " x:" + x + " y:" + y);

	}

	void MoveScene() {
		float PlayersAngle = PlayerController.angle;

		// move enemy in opposite direction the player is moving

		// set x
		if (PlayersAngle == 270 || PlayersAngle == 90) {
			x = 0;
		} else if (PlayersAngle > 90 && PlayersAngle < 270) {
			x = 1;  // player is going left, so go right instead
		} else {
			x = -1;
		};

		// set y
		if (PlayersAngle == 0 || PlayersAngle == 360 || PlayersAngle == 180) {
			y = 0;
		} else if (PlayersAngle > 0 && PlayersAngle < 180) {
			y = -1;  // player is going up, so go down instead
		} else {
			y = 1;
		};		
	}


}
