using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
	public float hpmax,currenthp,currentxp,levelxp;
	public int lvl = 1;
	public Image hpbar,xpbar;
	public int[] xpArr = new int[1];
	// Use this for initialization
	void Start () {
		currenthp = hpmax;
		levelxp = xpArr [lvl - 1];
	}
	
	// Update is called once per frame
	void Update () {
		currenthp = Mathf.Clamp (currenthp, 0f, hpmax);
		if (currenthp == 0f) {
			GetComponent<Animator> ().SetTrigger ("Death");
		}
		if (currentxp >= levelxp)
			UpLvl ();
		hpbar.fillAmount = currenthp / hpmax;
		xpbar.fillAmount = currentxp / levelxp;
	}
	void UpLvl(){
		currentxp -= levelxp;
		lvl++;
		levelxp = xpArr [lvl - 1];
	}
}
