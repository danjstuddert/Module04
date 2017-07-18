using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour {
	protected bool hasTriggered;

	public virtual void Trigger(){
		if (hasTriggered)
			return;

		if (hasTriggered == false)
			hasTriggered = true;
	}
}
