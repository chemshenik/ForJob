using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastSystem : MonoBehaviour {
	RaycastHit hit;
	public Transform camera;
	// Use this for initialization
	void Start () {
		camera = camera.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (camera.position, camera.transform.forward, out hit, 20f)) {
			if (hit.collider.tag == "Torch") {
				Debug.Log (hit.collider.tag);
				if (Input.GetKeyDown (KeyCode.E)) {
					GetComponent<Movement> ().canTurn = false;
					GetComponent<Movement> ().canMove = false;
					GetComponent<Animator> ().applyRootMotion = false;
					GetComponent<Animator> ().SetFloat ("Speed",1f);
					GetComponent<Movement> ().mY = 0;
					GetComponent<Movement> ().GoToPosition (transform.position, hit.collider.gameObject.GetComponent<Interactive> ().position,hit.collider.transform.position);
					GetComponent<equipItem> ().torchtemp = hit.collider.gameObject;

					//

					//transform.position = hit.collider.gameObject.GetComponent<Interactive> ().position.position;
					//transform.rotation = hit.collider.gameObject.GetComponent<Interactive> ().position.rotation;
				}
			}
		}
		Debug.DrawRay (camera.position, camera.transform.forward * 20f, Color.green);
	}
}
