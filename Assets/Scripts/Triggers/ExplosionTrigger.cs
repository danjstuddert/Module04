using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : Triggerable {
	public ParticleSystem explosionParticle;
	public AudioClip explosionSound;
	public List<Rigidbody> shipPieces;
	public float explosionForce;
	public float explosionRadius;

	public override void Trigger () {
		if (hasTriggered)
			return;

		base.Trigger ();

		Vector3 heading = transform.position - GameObject.FindWithTag("Player").transform.position;
		float distance = heading.magnitude;
		Vector3 direction = heading / distance;

		AudioSource.PlayClipAtPoint (explosionSound, direction, 50);
		Invoke("Explode", explosionSound.length / 5);
	}

	private void Explode() {
		for (int i = 0; i < shipPieces.Count; i++) {
			SimplePool.Spawn(explosionParticle.gameObject, shipPieces[i].position, Quaternion.identity);
			shipPieces[i].isKinematic = false;
			shipPieces[i].AddExplosionForce(explosionForce, GameObject.FindWithTag("AlienShip").transform.position, explosionRadius, 0f, ForceMode.Impulse);
		}
	}
}
