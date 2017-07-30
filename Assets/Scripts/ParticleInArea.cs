using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleInArea : MonoBehaviour {
	public List<ParticleSystem> particles;
	public float spawnRadius;
	public float spawnHeight;
	public float minSpawnTime;
	public float maxSpawnTime;
	public int minNumSpawn;
	public int maxNumSpawn;

	private float currentSpawnTime;
	private float spawnCounter;

	void Start () {
		ResetSpawnTime();
	}
	
	// Update is called once per frame
	void Update () {
		spawnCounter += Time.deltaTime;

		if (spawnCounter < currentSpawnTime)
			return;

		int numToSpawn = Random.Range(minNumSpawn, maxNumSpawn + 1);
		for (int i = 0; i < numToSpawn; i++) {
			SpawnParticle();
		}

		ResetSpawnTime();
	}

	private void ResetSpawnTime() {
		currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
		spawnCounter = 0f;
	}

	private void SpawnParticle() {
		Vector3 spawnLocation = Random.insideUnitSphere * spawnRadius;

		spawnLocation.y = spawnHeight;

		//Get a random particle from the list
		SimplePool.Spawn(particles[Random.Range(0, particles.Count)].gameObject, spawnLocation, Quaternion.identity);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere(new Vector3(transform.position.x, spawnHeight, transform.position.z), spawnRadius);
	}
}
