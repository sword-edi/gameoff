using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public Slider healthBar;

	GameObject scene;
	float amount = 100f;
	float max = 100f;

	// Use this for initialization
	void Start () {
		scene = GameObject.Find("CaptureZone");
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
			Debug.Log(gameObject + ": \"I'm dead!\"");
			Destroy(gameObject);
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
