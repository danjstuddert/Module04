using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour {
	[Header("Audio")]
	public bool playClipAtPoint;
	public AudioClip clipToPlay;

	private bool hasPoint;

	private Vector3 point;
	private float speed;

	private TrailRenderer trail;

	public void Init(Vector3 moveToPoint, float moveToSpeed) {
		point = moveToPoint;
		speed = moveToSpeed;

		hasPoint = true;

		if (trail == null)
			trail = GetComponent<TrailRenderer>();

		ResetLineRenderer();
	}

	void Update () {
		Move();
	}

	private void Move() {
		if (hasPoint == false)
			return;

		if(transform.position != point) {
			transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
		}
		else {
			Despawn();
		}
	}

	private void Despawn() {
		if (playClipAtPoint)
			AudioSource.PlayClipAtPoint(clipToPlay, transform.position);


		trail.enabled = false;
		SimplePool.Despawn(gameObject);
	}

	private void ResetLineRenderer() {
		trail.Clear();
		trail.enabled = true;
	}
}
