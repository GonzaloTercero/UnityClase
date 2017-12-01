using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleEnemy : MonoBehaviour {
	public GameObject obj;
	private Rigidbody rb;
	private Rigidbody rbAjeno;
	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody> ();
		rbAjeno = obj.GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//tengo que calcular el vector de movimiento

		transform.LookAt (rbAjeno.transform);
		transform.Translate (Vector3.forward * 4* Time.deltaTime);

	}


	void OnCollisionEnter(Collision c){

	}

}
