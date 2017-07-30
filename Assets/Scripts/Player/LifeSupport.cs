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

	private float currentLifeAmount;
	private bool hasDied;

	// Use this for initialization
	void Start () {
		currentLifeAmount = lifeAmount;
		UIController.Instance.UpdateLifeSupportText(currentLifeAmount);
	}
	
	// Update is called once per frame
	void Update () {
		DrainLifeSupport ();	
	}

	private void DrainLifeSupport(){
		currentLifeAmount -= lifeDrainPerSecond * Time.deltaTime;
		UIController.Instance.UpdateLifeSupportText(currentLifeAmount);

		if (currentLifeAmount <= frostIncreaseStart)
			GrowFrostEffect();

		if (currentLifeAmount <= 0f)
			Die ();
	}

	private void GrowFrostEffect() {
		frost.FrostAmount += frostIncreaseAmount * Time.deltaTime;
	}

	private void Die(){
		Vector3 direction = crashingPod.transform.position - transform.position;
		direction = Vector3.RotateTowards(transform.forward, direction, lookAtSpeed * Time.deltaTime, 0f);
		transform.rotation = Quaternion.LookRotation(direction);

		if (hasDied)
			return;

		GetComponent<PlayerController>().enabled = false;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		GameController.Instance.PlayerDead ();

		hasDied = true;
	}
}
