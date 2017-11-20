using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClick : MonoBehaviour {

	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void PlaySound() {
		audio.Play();
	}

	public void ContinueGame() {
		PlaySound();
	}

	public void SelectLevel() {
		PlaySound();
	}

	public void SetOptions() {
		PlaySound();
	}

	public void QuitGame() {
		PlaySound();
		Application.Quit();
	}
}
