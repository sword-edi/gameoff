using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPosition : MonoBehaviour {
	public GameObject mouse;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = mouse.transform.position;

		if (mousePos.y < 0.1f) {
			mousePos.y = 0.1f;
		}
		mousePos.z = -0f;
		transform.position = mousePos;
	}
}
