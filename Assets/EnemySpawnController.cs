using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

	public GameObject Enemy; 

	public static int enemyCount = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyCount > 0) {
			// keep track of how many enemies are out there
			enemyCount = enemyCount - 1;

			// pick a quadrant to spawn enemy in
			float whatQuadrant = Random.Range(0, 4);
			
			float x = 0;
			float y = 0;

			if (whatQuadrant < 0) {
					x = Random.Range(-15, 15);
					y = 23;
			} else if (whatQuadrant < 1) {
					x = 16;
					y = Random.Range(-23, 23);
			} else if (whatQuadrant < 3) {
					x = Random.Range(-15, 15);
					y = -23;
			} else if (whatQuadrant < 4) {
					x = -16;
					y = Random.Range(-23, 23);
			}
			
			Vector3 xyPostion = new Vector3(x,y);
			Instantiate(Enemy, xyPostion, transform.rotation);
			
			Debug.Log("spawner cnt:" + enemyCount + " quad:" + whatQuadrant);
		}

	}
}
