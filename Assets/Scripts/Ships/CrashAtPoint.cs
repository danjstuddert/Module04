using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashAtPoint : MonoBehaviour {
	public Transform crashPoint;
	public float fallSpeed;
	public AudioClip crashSound;

	private bool shouldCrash;
	private bool hasPlayedClip;

	void Update () {
		if (shouldCrash == false)
			return;

		transform.position = Vector3.MoveTowards (transform.position, crashPoint.position, fallSpeed * Time.deltaTime);

		if (transform.position == crashPoint.position && crashSound != null && hasPlayedClip == false) {
			AudioSource.PlayClipAtPoint(crashSound, transform.position);
			hasPlayedClip = true;
		}
	}

	public void BeginCrash(){
		shouldCrash = true;
	}

	void OnDrawGizmosSelected(){
		if (crashPoint == null)
			return;

		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, crashPoint.position);
	}
}
