using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int isJumping;
	private int numMaxSaltos;
	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody>();
		isJumping = 0;
		numMaxSaltos = 2;
	}
	

	void FixedUpdate () {
		float horizontalAxis = Input.GetAxis("Horizontal");
		float verticalAxis = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(horizontalAxis, 0.0f,verticalAxis);
		rb.AddForce(movement*speed);

		if(Input.GetKeyDown("space") && numMaxSaltos > 0){
			Vector3 jumpForce = new Vector3(0.0f, 3.0f, 0.0f);
			rb.AddForce(jumpForce, ForceMode.Impulse);
			numMaxSaltos--;
		}
		rb.FreezeNotation;

		if (Input.GetKeyDown ("r") || Input.GetKey ("r")) {
			

		} else if (Input.GetKeyDown ("t")||  Input.GetKey ("t")) {
			

		} 



	}

	void OnCollisionEnter(Collision c){
		this.numMaxSaltos = 2;
		
	}
}
