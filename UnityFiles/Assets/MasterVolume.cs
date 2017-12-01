using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolume : MonoBehaviour {

	public float maxVolume = 0.2f;
	AudioSource source;

	// Use this for initializvioun
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (source.volume < maxVolume) {
			source.volume += 0.03f * Time.deltaTime;
		}
	}
}
