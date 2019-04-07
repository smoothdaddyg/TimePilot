using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour {

	public GameObject bullet;
	public float bulletForce;

	// Update is called once per frame
	void Update () {
		
		// check for input from fire key

		if (Input.GetButtonDown("Fire1")) {
			// create a new bullet object
			GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);

			// start the bullet moving in the direction the plane is
			newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce); 

			// destroy bullet after 5 seconds
			Destroy(newBullet,5.0f);
		}


	}
}
