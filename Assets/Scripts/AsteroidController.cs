using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
	private float speed;
	private float rotationSpeed;

	private float X;
	private float Z;

	private Rigidbody rb;

	public GameObject Player;

	void Start () {
		rb = GetComponent<Rigidbody> ();

		X = Random.Range (-0.5f, 0.5f);
		Z = Random.Range (-0.5f, 0.5f);

		rotationSpeed = Random.Range (1f, 2f);
		speed = Random.Range (1f, 4f);
	}

	void Update () {
		transform.Rotate (rotationSpeed,0,0);
		if(Player!=null)
			Attract ();
		Vector3 movement = new Vector3 (X, 0.0f, Z);
		rb.velocity = movement * speed;
	}


	void Attract (){
			Rigidbody rbToAttract = Player.GetComponent<Rigidbody> ();
			
			Vector3 direction = rb.position - rbToAttract.position;
			float distance = direction.magnitude;
			float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
			Vector3 force = direction.normalized * forceMagnitude;
			rbToAttract.AddForce(force);

	}
}
