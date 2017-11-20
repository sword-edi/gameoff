using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {
	PlayerControl playerCtrl;
	Health targetHealth;
	bool isEnemy;

	// Use this for initialization
	void Start () {
		if (CompareTag("CC")) {
			targetHealth = GameObject.Find("Player").GetComponent<Health>();
			isEnemy = true;
		} else {
			isEnemy = false;
		}

		if (CompareTag("Player")) {
			playerCtrl = GetComponent<PlayerControl>();
			isEnemy = false;
		} else {
			playerCtrl = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collider) {
		GameObject go = collider.gameObject;

		if (playerCtrl != null && go.name == "NormalEnemy") {
			playerCtrl.SetTarget(go);
			playerCtrl.SetMelee(true);
		}

		if (isEnemy && go.name == "Player") {
			targetHealth.DecreaseHealth(15);
		}
	}
}
