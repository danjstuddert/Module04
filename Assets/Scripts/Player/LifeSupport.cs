using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupport : MonoBehaviour {
	public float lifeAmount;
	public float lifeDrainPerSecond;
	public FrostEffect frost;
	public float frostIncreaseAmount;
	public float frostIncreaseStart;
	public Transform crashingPod;
	public float lookAtSpeed;

	public float CurrentLifeAmount { get; private set;}
	private bool hasDied;

	// Use this for initialization
	void Start () {
		CurrentLifeAmount = lifeAmount;
		UIController.Instance.UpdateLifeSupportText(CurrentLifeAmount);
	}
	
	// Update is called once per frame
	void Update () {
		DrainLifeSupport ();	
	}

	private void DrainLifeSupport(){
		CurrentLifeAmount -= lifeDrainPerSecond * Time.deltaTime;
		UIController.Instance.UpdateLifeSupportText(CurrentLifeAmount);

		if (CurrentLifeAmount <= frostIncreaseStart)
			GrowFrostEffect();

		if (CurrentLifeAmount <= 0f)
			Die ();
	}

	private void GrowFrostEffect() {
		frost.FrostAmount += frostIncreaseAmount * Time.deltaTime;
	}

	private void Die(){
		if (hasDied)
			return;

		GetComponent<PlayerController>().enabled = false;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		GameController.Instance.PlayerDead ();

		hasDied = true;
	}
}
