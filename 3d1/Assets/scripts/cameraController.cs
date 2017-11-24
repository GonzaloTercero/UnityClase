using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
	public GameObject obj;
	private Vector3 diff;
	private int maxDistance = 10;

	BallController bc;

	// Use this for initialization
	void Start () {
		//diff tiene que tener la diferencia de posiciones
		//entre mi GameObject camara y el GameObject que persigo
		transform.LookAt (obj.transform);
		this.bc = obj.GetComponent<BallController> ();
		this.diff = transform.position - obj.transform.position;
	}
	


	void LateUpdate () {
		/*if (Input.GetKeyDown ("r") || Input.GetKey ("r")) {
			transform.LookAt (obj.transform.position);
			transform.RotateAround (obj.transform.position, Vector3.up, Time.deltaTime * 20);
			this.UpdateDiff ();

		} else if (Input.GetKeyDown ("t") || Input.GetKey ("t")) {
			transform.LookAt (obj.transform.position);
			transform.RotateAround (obj.transform.position, Vector3.down, Time.deltaTime * 20);
			this.UpdateDiff ();

		} else if (Input.GetKeyDown ("g") || Input.GetKey ("g")) {
			transform.LookAt (obj.transform.position);
			transform.RotateAround (obj.transform.position, Vector3.right, Time.deltaTime * 20);
			this.UpdateDiff ();
		} else if (Input.GetKeyDown ("f") || Input.GetKey ("f")) {
			transform.LookAt (obj.transform.position);
			transform.RotateAround (obj.transform.position, Vector3.left, Time.deltaTime * 20);
			this.UpdateDiff ();
		}
		*/
		transform.position = bc.getRotation ()* diff + obj.transform.position;
		transform.LookAt (obj.transform.position);
	}
		
	void UpdateDiff(){
		this.diff = transform.position - obj.transform.position;
	}

}
