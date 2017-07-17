using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupport : MonoBehaviour {
	public float lifeAmount;
	public float lifeDrainPerSecond;

	private float currentLifeAmount;

	// Use this for initialization
	void Start () {
		currentLifeAmount = lifeAmount;
	}
	
	// Update is called once per frame
	void Update () {
		DrainLifeSupport ();	
	}

	private void DrainLifeSupport(){
		currentLifeAmount -= lifeDrainPerSecond * Time.deltaTime;

		//Do UI update here

		if (currentLifeAmount <= 0f)
			Die ();
	}

	private void Die(){
		Debug.Log ("Dead");
	}
}
