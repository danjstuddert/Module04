using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolume : MonoBehaviour {
	public Triggerable triggeredObject;

	private BoxCollider boxCollider;

	void Awake(){
		boxCollider = GetComponent<BoxCollider> ();

		if(boxCollider.isTrigger == false)
			transform.GetComponent<BoxCollider> ().isTrigger = true;
	}

	private void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			triggeredObject.Trigger ();
		}
	}

	private void OnDrawGizmosSelected(){
		Gizmos.color = new Color (1f, 0f, 0f, 0.5f);
		Gizmos.DrawCube (transform.position, transform.GetComponent<BoxCollider>().size);

		Gizmos.color = Color.red;

		if(triggeredObject)
			Gizmos.DrawLine (transform.position, triggeredObject.transform.position);
	}
}
