using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaveFunction{ SIN, TRI, SQR, SAW, INV, NOISE }

public class Flicker : MonoBehaviour {
	public WaveFunction waveFunction;
	public float lightBase;
	public float amplitude;
	public float phase;
	public float frequency;

	private Color originColour;
	private Light myLight;

	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light> ();

		if (myLight)
			originColour = myLight.color;
		else
			Debug.LogError (string.Format ("{0} has a flicker component but has no light attached", transform.name));
	}
	
	// Update is called once per frame
	void Update () {
		if (myLight == null)
			return;

		myLight.color = originColour * (EvaluateWave ());
	}

	private float EvaluateWave(){
		float x = (Time.time + phase) * frequency;
		float y;

		x = x - Mathf.Floor (x);

		switch (waveFunction) {
		case WaveFunction.SIN:
			y = Mathf.Sin (x * 2f * Mathf.PI);
			break;
		case WaveFunction.TRI:
			y = x < 0.5f ? y = 4f * x - 1f : y = -4f * x + 3f;
			break;
		case WaveFunction.SQR:
			y = x < 0.5f ? 1f : -1f;
			break;
		case WaveFunction.SAW:
			y = x;
			break;
		case WaveFunction.INV:
			y = 1f - x;
			break;
		case WaveFunction.NOISE:
			y = 1 - (Random.value * 2);
			break;
		default:
			y = 1f;
			break;
		}

		return (y * amplitude) + lightBase;
	}
}
