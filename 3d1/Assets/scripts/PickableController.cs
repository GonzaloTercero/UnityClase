using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableController : MonoBehaviour {

	public GameObject myObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rotation = new Vector3(0.0f ,50.5f ,0.0f);
		transform.Rotate (rotation * Time.deltaTime, Space.Self);
	}

	void OnTriggerEnter(Collider c){

		if (c.gameObject.tag == "Player") {
			myObject.SetActive (false);

			BallController bc = c.gameObject.GetComponent<BallController> ();
			if (bc == null) {
				// SI bc es null significa que el gameObject no tiene
				// el componente BallController.
				Debug.Log ("Error, component BallController no detectado");
			} else {
				// el gameObject tiene el componente BallController
				bc.sumCounter ();
			}

		}
	}
}
