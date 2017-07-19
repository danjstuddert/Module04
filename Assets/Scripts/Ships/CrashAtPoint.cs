using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashAtPoint : MonoBehaviour {
	public Transform crashPoint;
	public float fallSpeed;

	private bool shouldCrash;

	void Update () {
		if (shouldCrash == false)
			return;

		transform.position = Vector3.MoveTowards (transform.position, crashPoint.position, fallSpeed * Time.deltaTime);
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
