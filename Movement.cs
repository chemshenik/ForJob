using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {
	public bool canTurn = true,canMove = true;
	Transform playerTransform;
	public Transform camera;
	Animator animator;
	public float mX = 0,mY = 0;
	public float minY, maxY;
	NavMeshAgent agent;
	Vector3 tempobj,tempend;
	Quaternion temprot;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.enabled = false;
		animator = GetComponent<Animator> ();
		playerTransform = GetComponent<Transform> ();
		camera = camera.GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if (canTurn)
			Turn ();
		if (canMove)
			Move ();
		else {
			Debug.Log(Vector3.Distance (transform.position, tempend));
			if (Vector3.Distance (transform.position, tempend) < 0.1f) {
				tempend = transform.forward * 5f;
				GetComponent<NavMeshAgent> ().enabled = false;
				transform.rotation = temprot;
				animator.SetTrigger ("Interactive");
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha1))
			animator.SetBool ("EquipSword",true);
		if (Input.GetKeyDown (KeyCode.Alpha2))
			animator.SetTrigger ("Equip");
		if (Input.GetKeyDown (KeyCode.Alpha3))
			animator.SetBool ("EquipTorch",true);
		animator.SetBool ("Aiming", Input.GetKey (KeyCode.Mouse0));
	}
	public void GoToPosition(Vector3 start, Transform end,Vector3 obj){
		temprot = end.rotation;
		tempend = end.position;
		tempobj = obj;
		agent.enabled = true;
		agent.SetDestination (end.position);
	}
	void Move(){
		animator.SetFloat ("Speed", Input.GetAxis ("Vertical"));
		animator.SetFloat ("Direction", Input.GetAxis ("Horizontal"));
	}
	void Turn(){
		mX += Input.GetAxis ("Mouse X") * 40 * Time.deltaTime;
		mY -= Input.GetAxis ("Mouse Y") * 40 * Time.deltaTime;
		mY = Mathf.Clamp (mY, minY, maxY);
		playerTransform.rotation = Quaternion.Euler(0,mX,0);
		camera.rotation = Quaternion.Euler(mY,mX,0);
	}
}
