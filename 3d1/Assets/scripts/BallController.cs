using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody>();
		this.speed = 5;
	}
	

	void FixedUpdate () {
		float horizontalAxis = Input.GetAxis("Horizontal");
		float verticalAxis = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(horizontalAxis, 0.0f,verticalAxis);
		rb.AddForce(movement*speed);
	}
}
