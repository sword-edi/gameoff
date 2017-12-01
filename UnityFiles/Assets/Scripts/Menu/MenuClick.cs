using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour {

	AudioSource source;

	void Start() {
		source = GetComponent<AudioSource>();
		Cursor.visible = true;
	}

	void PlaySound() {
		source.Play();
	}

	public void RestartGame() {
		PlaySound();
		SceneManager.LoadScene("IA", LoadSceneMode.Single);
	}

	public void ContinueGame() {
		PlaySound();
		SceneManager.LoadScene("IA", LoadSceneMode.Single);
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
