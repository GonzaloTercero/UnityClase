using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	float forwardInput;
	float turnInput;
	Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody>();
		targetRotation = transform.rotation;
	}
	
	void Update(){
		getInput ();
		turn();
	}


	void FixedUpdate () {
		if(Mathf.Abs (forwardInput) > 0.01f){
			rb.velocity = transform.forward * speed * forwardInput;	
		}

		
	}

	void getInput(){
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");

	}

	void OnCollisionEnter(Collision c){
		
		
	}

	void turn(){
		targetRotation *= Quaternion.AngleAxis (100 * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

	public Quaternion getRotation(){
		return this.targetRotation;
	}
}
