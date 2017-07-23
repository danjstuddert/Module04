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
	private float currentFallSpeed;
	private float count;

	private Transform trailParent;

	// Use this for initialization
	void Start () {
		trailParent = new GameObject().transform;
		trailParent.name = "CrashTrailParent";

		SetSpawnParameters ();
	}

	void SetSpawnParameters(){
		count = 0f;
		currentSpawnTime = Random.Range (minSpawnTime, maxSpawnTime);
		currentFallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
	}

	void Update() {
		CheckTrailSpawn();
	}

	private void CheckTrailSpawn() {
		count += Time.deltaTime;

		if (count >= currentSpawnTime) {
			SpawnTrail();
			SetSpawnParameters();
		}
	}

	private void SpawnTrail(){
		Vector3 point = RandomPointOnUnitCircle (spawnRadius);
		point = new Vector3 (point.x, spawnHeight, point.y);

		//Spawn in the trail
		GameObject go = SimplePool.Spawn(crashTrail, point, Quaternion.identity);
		go.transform.SetParent(trailParent);

		//Give the trail a point to move to
		point = RandomPointOnUnitCircle(crashRadius);
		point = new Vector3(point.x, 0f, point.y);
		go.GetComponent<MoveToPoint>().Init(point, currentFallSpeed);
	}

	void OnValidate(){
		if (crashRadius < spawnRadius)
			crashRadius = spawnRadius;

		if (maxSpawnTime < minSpawnTime)
			maxSpawnTime = minSpawnTime;
	}

	public static Vector2 RandomPointOnUnitCircle(float radius) {
		float angle = Random.Range (0f, Mathf.PI * 2);
		float x = Mathf.Sin (angle) * radius;
		float y = Mathf.Cos (angle) * radius;

		return new Vector2 (x, y);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, spawnRadius);

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, crashRadius);
	}
}
