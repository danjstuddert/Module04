using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {
	public CrashAtPoint crashingPod;

	void Start () {
		if (crashingPod.gameObject.activeInHierarchy)
			crashingPod.gameObject.SetActive (false);
	}

	public void PlayerDead(){
		crashingPod.gameObject.SetActive (true);
		crashingPod.BeginCrash ();
	}
}
