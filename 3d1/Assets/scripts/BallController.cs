using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int counter;
	float forwardInput;
	float turnInput;
	Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		Physics.gravity= new Vector3(0f,-60f,0f);
		this.counter = 0;
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
		//c.gameObject.tag
		Debug.Log ("Colision " + c.gameObject.tag );
		if(c.gameObject.tag == "Pickable"){
			counter++;
			Debug.Log (counter);
			c.gameObject.SetActive(false);
		}else if (c.gameObject.tag == "Enemy"){
			Vector3  hitVector =  c.transform.position - transform.position;
			Vector3 revector = new Vector3 (hitVector.x, 0.0f, hitVector.z);
			Rigidbody rbaj = c.gameObject.GetComponent<Rigidbody> ();
			rbaj.AddForce (-c.transform.forward+hitVector* 15, ForceMode.Impulse);
			rb.AddRelativeForce (-c.transform.forward - hitVector* 15, ForceMode.Impulse);


			float longitud = Vector3.Distance(transform.position, -c.transform.forward - hitVector* 15);
			transform.position = Vector3.Lerp (transform.position, -c.transform.forward - hitVector* 5, (longitud/100) );
	
		}
	}

	void OnTriggerEnter(Collider c){
		Debug.Log ("Colision " + c.gameObject.tag );
	
	}
	void turn(){
		targetRotation *= Quaternion.AngleAxis (100 * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

	public Quaternion getRotation(){
		return this.targetRotation;
	}


	public void sumCounter(){
		counter++;
		Debug.Log ("Counter " + counter  );
	}

}
