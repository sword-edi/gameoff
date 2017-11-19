using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour {
	public Camera cam;
	public GameObject player;

	Ray camRay;
	RaycastHit camHit;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		camRay = cam.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(camRay, out camHit, 100f)) {
			Vector3 newPosition = camHit.point;
			newPosition.z = 0f;
			transform.position = newPosition + player.transform.position;
		}
	}
}
