using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : Triggerable {
	public ParticleSystem explosionParticle;
	public AudioClip explosionSound;

	public override void Trigger () {
		explosionParticle.Play ();
		AudioSource.PlayClipAtPoint (explosionSound, transform.position);
	}
}
