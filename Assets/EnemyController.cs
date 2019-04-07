using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	public Rigidbody2D rb;
	public GameObject Player;
	public GameObject Explosion; 

	int EnemyAngleIncrement;
	bool rotateClockwise = true;
	int EnemyDirection = 90;
	float EnemySpeed; 

	float timer = 1.0f;
	float timerAction = 1.0f;  // time to wait before action
	float PlayerDirection;   

	Vector2 dest = Vector2.zero;
	int x, y;
	


	// Use this for initialization
	void Start () {
		// set start angle
		//rb.transform.Rotate(0,0,-EnemyDirection);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// rotate enemy fighter towards player every few seconds
		// ------------------------------------------------------------------
		timer = timer + Time.deltaTime;

		// is it time to update enemy direction?
		if (timer > timerAction) {

			RotateEnemy();

		}

		// Move Enemy based on Players movement
		MoveScene(); 

		// Move Enemy based on it's direction
		MoveEnemyPlane();

		
		// Update new Enemies position
		// ------------------------------------------------------------------
		
		// calculate new position
		dest = (Vector2)transform.position + new Vector2(x,y);
		
		// tell unity physics engine to move sprite to new location at given speed
		EnemySpeed = Random.Range(0.01f, 0.20f);
		Vector2 p = Vector2.MoveTowards(transform.position, dest, EnemySpeed);
		rb.MovePosition(p);

	}


	void MoveEnemyPlane() {

		int moveIncrement = Random.Range(1,3);

		// adjust enemies movement based on it's current direction
		if (EnemyDirection > 340 && EnemyDirection < 20) {
			x += moveIncrement; //1;
			y = 0;
		};
		if (EnemyDirection > 20 && EnemyDirection < 70) {
			x += moveIncrement; // 1;
			y += moveIncrement; // 1;
		};
		if (EnemyDirection > 70 && EnemyDirection < 110) {
			x = 0;
			y += moveIncrement; // 1;
		};
		if (EnemyDirection > 110 && EnemyDirection < 160) {
			x -= moveIncrement; // 1;
			y += moveIncrement; // 1;
		};
		if (EnemyDirection > 160 && EnemyDirection < 200) {
			x -= moveIncrement; // 1;
			y = 0;
		};
		if (EnemyDirection > 200 && EnemyDirection < 250) {
			x -= moveIncrement; // 1;
			y -= moveIncrement; // 1;
		};
		if (EnemyDirection > 200 && EnemyDirection < 290) {
			x = 0;
			y -= moveIncrement; // 1;
		};
		if (EnemyDirection > 290 && EnemyDirection < 340) {
			x += moveIncrement; // 1;
			y -= moveIncrement; // 1;
		};



	}

	void MoveScene() {
		PlayerDirection = PlayerController.angle;

		// move enemy in opposite direction the player is moving

		// set x
		if (PlayerDirection == 270 || PlayerDirection == 90) {
			x = 0;
		} else if (PlayerDirection > 90 && PlayerDirection < 270) {
			x = 1;  // player is going left, so go right instead
		} else {
			x = -1;
		};

		// set y
		if (PlayerDirection == 0 || PlayerDirection == 360 || PlayerDirection == 180) {
			y = 0;
		} else if (PlayerDirection > 0 && PlayerDirection < 180) {
			y = -1;  // player is going up, so go down instead
		} else {
			y = 1;
		};		
	}

	void RotateEnemy() {
	
			// get the angle which points to the player
			float Direction2Player = Mathf.Atan2(Player.transform.position.y - gameObject.transform.position.y, Player.transform.position.x - gameObject.transform.position.x) * Mathf.Rad2Deg;

			// range is -180 to 180, so normalize to 0 to 360
			if (Direction2Player < 0) {
				Direction2Player += 360;
			}


			// find difference between direction2player and enemydirection
			if (Direction2Player > EnemyDirection) {
				if (Direction2Player - EnemyDirection < 180) {
					rotateClockwise = false;
				} else {
					rotateClockwise = true;
				}
			} else {
				if (EnemyDirection - Direction2Player < 180) {
					rotateClockwise = true;
				} else {
					rotateClockwise = false;
				}				
			}

//Debug.Log(Time.time + "> timer:" + timer + " enemydirection:" + EnemyDirection + " direction2player:" + Direction2Player);


			// set increment to rotate enemy 
			if (rotateClockwise) {
				EnemyAngleIncrement = -10;
			} else {
				EnemyAngleIncrement = 10;
			}


			// update our enemies direction
			EnemyDirection += EnemyAngleIncrement;
			if (EnemyDirection > 360 ) {
				EnemyDirection = EnemyDirection - 360;  // if it's 370 make it 10
			}
			if (EnemyDirection < 0) {
				EnemyDirection = EnemyDirection + 360;  // if it's -10 make it 350
			}

			// rotate enemy
			rb.transform.Rotate(0,0, EnemyAngleIncrement);

			// reset timer and timerAction
			timer = 0.0f;			
			timerAction = timerAction = Random.Range(0.5f, 1.0f);
	
	}


	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("collision " + col.gameObject.name + " " + gameObject.tag);

		// was enemy hit by a bullet?
		if (col.gameObject.tag.Equals("bullet")) {

			// create explosion 
			Instantiate(Explosion, transform.position, transform.rotation);

			// update enemy counter
			EnemySpawnController.enemyCount += 1;

			Destroy(gameObject);
		}
		
	}	





}
