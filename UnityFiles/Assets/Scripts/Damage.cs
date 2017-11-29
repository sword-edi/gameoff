using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	View view;

	// Use this for initialization
	void Start () {
		if (CompareTag("Tir") || CompareTag("CC")) {
			view = GetComponent<View>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(Vector3 source, float damage = 10f) {
		Health hp = gameObject.GetComponent<Health>();

		if (hp != null) {
			hp.DecreaseHealth(damage);

			if (view != null) {
				StartCoroutine(Wait(source));
			}
		}
	}

	private IEnumerator Wait(Vector3 source) {
		yield return new WaitForSeconds(0.3f);
		source.y = 1.7f;
		transform.LookAt(source);
		yield return new WaitForSeconds(0.4f);
	}
}
