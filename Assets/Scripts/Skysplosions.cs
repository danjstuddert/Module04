using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skysplosions : MonoBehaviour {
	public List<ParticleSystem> particles;
	public float spawnRadius;
	public float spawnHeight;
	public float minSpawnTime;
	public float maxSpawnTime;
	public int minNumSpawn;
	public int maxNumSpawn;

	public List<AudioClip> explosionSounds;
	public float audioDistanceFromPlayer;

	private float currentSpawnTime;
	private float spawnCounter;
	private Vector3 lastSpawnLocation;

	private Transform player;

	void Start () {
		ResetSpawnTime();

		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		spawnCounter += Time.deltaTime;

		if (spawnCounter < currentSpawnTime)
			return;

		int numToSpawn = Random.Range(minNumSpawn, maxNumSpawn + 1);
		for (int i = 0; i < numToSpawn; i++) {
			SpawnParticle();
			SpawnExplosionSound();
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

		lastSpawnLocation = spawnLocation;

		//Get a random particle from the list and spawn it
		SimplePool.Spawn(particles[Random.Range(0, particles.Count)].gameObject, spawnLocation, Quaternion.identity);
	}

	private void SpawnExplosionSound() {
		Vector3 heading = lastSpawnLocation - player.position;
		float distance = heading.magnitude;
		Vector3 direction = heading / distance;

		direction *= audioDistanceFromPlayer;
		AudioSource.PlayClipAtPoint(explosionSounds[Random.Range(0, explosionSounds.Count)], player.position + direction);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere(new Vector3(transform.position.x, spawnHeight, transform.position.z), spawnRadius);
	}
}
