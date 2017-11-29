using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public Slider healthBar;

	ZoneDetection captureZone;
	float amount = 100f;
	float max = 100f;
	SceneManager sceneMgr;

	// Use this for initialization
	void Start () {
		captureZone = GameObject.Find("CaptureZone").GetComponent<ZoneDetection>();
	}
	
	// Update is called once per frame
	void Update () {
		if (healthBar != null) {
			healthBar.value = amount;
		}
	}

	public void SetHealth(float _amount = 100f) {
		amount = _amount;
	}

	public float GetHealth() {
		return amount;
	}

	public float DecreaseHealth(float _amount = 10f) {
		amount -= _amount;
		if (amount <= 0) {
			bool isPlayer = CompareTag("Player");
			Scene currentScene = SceneManager.GetActiveScene();

			if (isPlayer) {
				Destroy(GameObject.Find("Gun"));
				SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
				SceneManager.UnloadSceneAsync("IA");
			}

			if (currentScene == SceneManager.GetActiveScene()) {
				Destroy(gameObject);
			}
		}
		return GetHealth();
	}

	public float IncreaseHealth(float _amount = 34f) {
		amount += _amount;

		if (amount > max) {
			amount = max;
		}
		return GetHealth();
	}

	public bool IsAlive() {
		return amount > 0;
	}
}
