using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {
	public CrashAtPoint crashingPod;

	void Start () {
		if (crashingPod.gameObject.activeInHierarchy)
			crashingPod.gameObject.SetActive (false);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	public void PlayerDead(){
		crashingPod.gameObject.SetActive (true);
		crashingPod.BeginCrash ();
	}
}
