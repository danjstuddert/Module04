using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour {
	public float minDistance;			// The minimum distance before the slow kicks in
	public float minWalkSpeed;
	public float slowScalar;			// The amount to slow the player speed by
	public Transform distanceMarker;
	public float lowLifeThreshold;

	private PlayerController player;
	private LifeSupport lifeSupport;
	private float baseWalkSpeed;
	private float baseRunSpeed;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController> ();
		lifeSupport = GetComponent<LifeSupport>();
		baseWalkSpeed = player.walkSpeed;
		baseRunSpeed = player.runSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		CheckDistance ();
		CheckLifeSupport();
	}

	private void CheckDistance(){
		if (player == null)
			return;

		float currentDistance = Vector3.Distance (transform.position, distanceMarker.position);

		if (currentDistance > minDistance) {
			//Remove the min distance from the current distance so we can use it as a scalar
			currentDistance -= minDistance;

			float newSpeed = baseWalkSpeed / (currentDistance * slowScalar);

			player.walkSpeed = newSpeed;

			//Run speed is set to the new speed as well because deeper snow, running seems weird
			player.runSpeed = newSpeed;

			if(player.walkSpeed > baseWalkSpeed){
				player.walkSpeed = baseWalkSpeed;
				player.runSpeed = baseRunSpeed;
			} else if(player.walkSpeed < minWalkSpeed){
				player.walkSpeed = minWalkSpeed;
				player.runSpeed = minWalkSpeed;
			}
		}
		else if(lifeSupport.CurrentLifeAmount > lowLifeThreshold){
			if(player.walkSpeed != baseWalkSpeed){
				player.walkSpeed = baseWalkSpeed;
				player.runSpeed = baseRunSpeed;
			}
		} 
			
	}

	private void CheckLifeSupport() {
		if (lifeSupport == null)
			return;

		if(lifeSupport.CurrentLifeAmount <= lowLifeThreshold && player.walkSpeed > 0) {
			player.walkSpeed -= Time.deltaTime / 5f;
			player.runSpeed -= Time.deltaTime / 5f;
		}
	}

	void OnDrawGizmosSelected(){
		if (distanceMarker == null)
			return;

		Gizmos.color = Color.red;

		Gizmos.DrawLine (transform.position, distanceMarker.position);
	}
}