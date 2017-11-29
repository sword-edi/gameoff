using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttach : MonoBehaviour {
	public GameObject attachObject;

	GameObject aim;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		aim = GameObject.FindGameObjectWithTag("Aim");
		offset = transform.position - attachObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = attachObject.transform.position + offset;
		newPosition.z = 0f;
		transform.position = newPosition;
		Vector3 d = aim.transform.position - transform.position;
		float a = Mathf.Rad2Deg * Mathf.Atan(d.y / d.x);

		if (a < 0) {
			a += 180;
		}

		if (aim.transform.position.y < transform.position.y) {
			a += 180;
		}
		transform.rotation = Quaternion.AngleAxis(a, Vector3.forward);
	}
}
