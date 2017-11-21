using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class TargetRotUpdate : MonoBehaviour {
	public ThirdPersonCharacter player;
	public GameObject cross;
	Vector3 frontGun = new Vector3(10f,110f,-75f);

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Vector3 ang = frontGun;
		Vector3 o = player.transform.position;
		o.z = 0f;
		o.y += 0.8f;
		Vector3 mousePos = new Vector3();
		mousePos.x = cross.transform.position.x - o.x;
		mousePos.y = cross.transform.position.y - o.y;
		float a = Mathf.Rad2Deg * Mathf.Atan(mousePos.y / mousePos.x);
		/*if (a < 0) {
			a += 180;
		}*/

		if (cross.transform.position.x < o.x) {
			ang.y += 180;
			ang.x = frontGun.x + a;
		} else {
			ang.x = frontGun.x - a;
		}

		this.transform.rotation = Quaternion.Euler(ang);
		//this.transform.rotation = Quaternion.AngleAxis(90f, Vector3.right);
		this.transform.position = cross.transform.position;
	}
}
