using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private float xMin = -50;
	private float xMax = 50;
	private float zMin = -50;
	private float zMax = 50;

	private Rigidbody rb;

	public GameObject Rocket;
	public Transform Launcher;

	private float fireRate = 1;
	private float fireDelay;

	private float speed = 0;
	public Text fuelCounter;
	private int fuel = 1000;
	private int fuelConsumption = 1;

	public GameObject explosion;

	public GameController gameController;

	public GameObject dick;


	void Start() {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update() {
		Fire ();
		Move ();
		Rotate();
		SetCounterText ();
	}

	void Fire () {
		if (Input.GetKey (KeyCode.Space) && Time.time > fireDelay) {
			fireDelay = Time.time + fireRate;
			Instantiate (Rocket, Launcher.position, Launcher.rotation);
		}
	}

	void Move () {
		if ((Input.GetKey (KeyCode.W) && (fuel!=0))){
			if (speed < 50f)
				speed += 2f;
			fuel = fuel - fuelConsumption;
		}
		if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S)){
			if (speed > 0.0f)
				speed -= 1f;
		}

		Vector3 force = transform.forward * speed;
		rb.AddForce(force);
	}

	void Rotate ()
	{
		if (Input.GetKey (KeyCode.D))
			transform.Rotate (transform.up, 100.0f*Time.deltaTime, Space.World);
		if (Input.GetKey (KeyCode.A))
			transform.Rotate (transform.up, -100.0f*Time.deltaTime, Space.World);
	}

	void SetCounterText (){
		fuelCounter.text = "Fuel: " + fuel.ToString ();
	}
		
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Border")
			return;
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		gameController.GameOver ();
		Destroy(gameObject);
	}


	void CheckBorderOfSpace(){
		if ((rb.position.x <= xMin) || (rb.position.x >= xMax)) {
			Instantiate (dick, transform.position, transform.rotation);
			Destroy (this);
		}
		if ((rb.position.z <= zMin) || (rb.position.z >= zMax)) {
			Instantiate (dick, transform.position, transform.rotation);
			Destroy (this);
		}
	}
}
