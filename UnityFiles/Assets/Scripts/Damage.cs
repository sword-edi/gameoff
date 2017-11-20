using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage = 10f) {
		Health hp = gameObject.GetComponent<Health>();

		if (hp != null) {
			hp.DecreaseHealth(damage);
		}
	}
}
