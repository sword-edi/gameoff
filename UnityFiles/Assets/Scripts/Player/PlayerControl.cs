using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	Rigidbody rb;
	Vector3 movement;
	float speed = 5f;
	bool grounded = false;
	float groundPosition;
	Vector3 beforeJump;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		groundPosition = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxisRaw("Horizontal");

		if (Input.GetButton("Jump") && grounded) {
			grounded = false;
			rb.AddForce(new Vector3(0f, 4f, 0f), ForceMode.Impulse);
		}
		Move(x);
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.name == "Ground") {
			grounded = true;
		}
	}

	void Move(float x) {
		movement.Set(x, 0f, 0f);
		movement = movement * speed * Time.deltaTime;
		rb.MovePosition(transform.position + movement);
	}
}
