using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour {

	public GameObject shootable;
	private GameObject player;
	//A donde miro.

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		StartCoroutine (Fire());
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt (player.transform.position);

	}

	private IEnumerator Fire(){
		while (true) {
			GameObject shoot = (GameObject) Instantiate (shootable,shootable.transform.position,shootable.transform.rotation);
			shoot.SetActive (true);
			Vector3 diffForce = player.transform.position - shoot.transform.position;
			shoot.transform.LookAt(player.transform.position);
			shoot.GetComponent<Rigidbody>().velocity = diffForce ;

			Destroy (shoot, 2);
			yield return new WaitForSeconds (3.0f);

		}
	}
}
