using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, 15f);
	}
	void OnTriggerEnter (Collider col){
		GetComponent<Rigidbody> ().isKinematic = true;
		if (col.GetComponent<EnemySystem> () != null)
			col.GetComponent<EnemySystem> ().GetDamage (25);
		Debug.Log ("Collision");
	}
}
