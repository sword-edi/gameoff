using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float speed = 6f;

    Vector3 movement;
    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxisRaw("Horizontal");

        Move(x);
	}

    void Move(float x)
    {
        movement.Set(x, 0f, 0f);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidBody.MovePosition(transform.position + movement);
    }
}
