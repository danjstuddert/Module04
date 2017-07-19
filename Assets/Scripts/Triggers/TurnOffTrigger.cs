using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTrigger : Triggerable {
	public List<GameObject> turnOffObjectList;

	public override void Trigger () {
		base.Trigger ();

		for (int i = 0; i < turnOffObjectList.Count; i++) {
			turnOffObjectList[i].SetActive (false);
		}
	}

	void OnDrawGizmosSelected(){
		if (turnOffObjectList != null)
			return;

		Gizmos.color = Color.red;

		for (int i = 0; i < turnOffObjectList.Count; i++) {
			Gizmos.DrawLine (transform.position, turnOffObjectList [i].transform.position);
		}
	}
}
