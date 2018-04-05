using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class equipItem : MonoBehaviour {
	public Transform bow,bowplace,bowplaceequip,torchplace,swordplace,swordplaceequip;
	public bool equiped;
	public float ArrowSpeed;
	public GameObject arrow, arrowPlace,arrowtemp,torch,torchtemp,sword;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (equiped) {
			bow.position = bowplaceequip.position;
			bow.rotation = bowplaceequip.rotation;
		}
	}
	public void EquipSword(){
		sword.transform.parent = swordplaceequip;
		sword.transform.position = swordplaceequip.position;
		sword.transform.rotation = swordplaceequip.rotation;
		GetComponent<Animator>().SetBool ("EquipSword",false);
	}
	public void SheathSword(){
		sword.transform.parent = swordplace;
		sword.transform.position = swordplace.position;
		sword.transform.rotation = swordplace.rotation;
		GetComponent<Animator>().SetBool ("EquipSword",false);
	}
	public void EquipTorch(){
		torchtemp = Instantiate (torch, torchplace.transform.position, torchplace.transform.rotation, torchplace.transform) as GameObject;
		GetComponent<Animator>().SetBool ("EquipTorch",false);
	}
	public void DropTorch(){
		torchtemp.GetComponent<Rigidbody> ().isKinematic = false;
		torchtemp.transform.parent = null;
		torchtemp = null;
	}
	public void EquipBow(){
		if (torchtemp != null) {
			DropTorch ();
		}
		equiped = true;
	}
	public void UnEquipBow(){
		bow.position = bowplace.position;
		bow.rotation = bowplace.rotation;
		equiped = false;
	}
	public void DrawArrow(){
		arrowtemp = Instantiate (arrow, arrowPlace.transform.position, arrowPlace.transform.rotation, arrowPlace.transform) as GameObject;
	}
	public void WithdrawArrow(){
		arrowtemp.transform.parent = null;
		arrowtemp.GetComponent<Rigidbody> ().isKinematic = false;
		arrowtemp.GetComponent<Rigidbody> ().AddForce (-arrowtemp.transform.up*ArrowSpeed, ForceMode.Force);  
	}
	public void PickUpTorch(){
		torchtemp.transform.parent = torchplace.transform;
		torchtemp.transform.position = torchplace.transform.position;
		torchtemp.transform.rotation = torchplace.transform.rotation;
	}
	public void CanTurn(){
		GetComponent<Movement> ().canTurn = true;
		GetComponent<Movement> ().canMove = true;
		GetComponent<Animator> ().applyRootMotion = true;
	}
}
