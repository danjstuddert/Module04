using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour {
	public List<AudioClip> footsteps;
	public float minVelocity;
	public float baseWaitTime;

	private PlayerController playerController;
	private Rigidbody rBody;
	private AudioSource audioSource;
	private float currentWaitTime;
	private float waitTimeCount;

	void Start () {
		playerController = GetComponent<PlayerController>();
		rBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		PlayStep();
	}

	private void PlayStep() {
		currentWaitTime = baseWaitTime / playerController.walkSpeed;
		waitTimeCount += Time.deltaTime;

		if (waitTimeCount < currentWaitTime)
			return;

		waitTimeCount = 0f;

		if(rBody.velocity.magnitude > minVelocity && audioSource.isPlaying == false) {
			audioSource.PlayOneShot(footsteps[Random.Range(0, footsteps.Count)]);
		}
	}
}
