using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class TargetRotUpdate : MonoBehaviour {
	public ThirdPersonCharacter player;
	public GameObject cross;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 o = player.transform.position;
		o.z = 0f;
		o.y += 0.8f;
		Vector3 mousePos = new Vector3();
		mousePos.x = Input.mousePosition.x - o.x;
		mousePos.y = Input.mousePosition.y - o.y;
		mousePos = mousePos.normalized;
		//Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
		Vector3 front = new Vector3(1,0,0);
		Quaternion temp = new Quaternion();
		temp.SetFromToRotation (front, mousePos);
		//temp.SetLookRotation(mousePos);
		this.transform.position = cross.transform.position;
		this.transform.rotation = temp;
	}
}
