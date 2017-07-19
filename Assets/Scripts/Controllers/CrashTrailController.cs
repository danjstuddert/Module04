using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashTrailController : MonoBehaviour {
	public GameObject crashTrail;
	public float minFallSpeed;
	public float maxFallSpeed;

	[Header("Spawning")]
	public float minSpawnTime;
	public float maxSpawnTime;
	public float spawnHeight;			//This will be added to the transforms y position
	public float spawnRadius;
	public float crashRadius;

	private float currentSpawnTime;
	private float count;

	// Use this for initialization
	void Start () {
		SetSpawnTime ();
	}

	void SetSpawnTime(){
		count = 0f;
		currentSpawnTime = Random.Range (minSpawnTime, maxSpawnTime);
	}

	void SpawnTrail(){
		Vector3 point = RandomPointOnUnitCircle (spawnRadius);
		point = new Vector3 (point.x, spawnHeight, point.y);

//		SimplePool.Spawn ();
	}

	void OnValidate(){
		if (crashRadius < spawnRadius)
			crashRadius = spawnRadius;

		if (maxSpawnTime < minSpawnTime)
			maxSpawnTime = minSpawnTime;

		//SimplePool.Spawn()
	}

	public static Vector2 RandomPointOnUnitCircle(float radius) {
		float angle = Random.Range (0f, Mathf.PI * 2);
		float x = Mathf.Sin (angle) * radius;
		float y = Mathf.Cos (angle) * radius;

		return new Vector2 (x, y);
	}
}
