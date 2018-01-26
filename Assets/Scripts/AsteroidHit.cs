using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour {

	public GameObject explosion;
	public GameController gameController;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Border")
			return;
		Instantiate(explosion, transform.position, transform.rotation);
		gameController.AddScore (1);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
