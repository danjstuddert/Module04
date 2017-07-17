using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour {
	public float minDistance;			// The minimum distance before the slow kicks in
	public float slowScalar;			// The amount to slow the player speed by

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
			return;


	}

	private void CheckDistance(){
		
	}
}