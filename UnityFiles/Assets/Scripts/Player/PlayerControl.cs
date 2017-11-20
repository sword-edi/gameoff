using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public GameObject gun;

	Rigidbody rb;
	Vector3 movement;
	float speed = 5f;
	bool grounded = false;
	float groundPosition;
	Vector3 beforeJump;
	GunShoot shooter;
	Health health;
	bool melee;
	GameObject target;
	Health targetHealth;
	Damage targetDamage;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		health = GetComponent<Health>();
		groundPosition = 0f;
		melee = false;
		target = null;
		targetHealth = null;
		targetDamage = null;

		if (gun != null)
			shooter = gun.GetComponent<GunShoot>();
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetButtonDown("Fire1") && health.IsAlive()) {
			shooter.SetShooting(true);
		}

		if (Input.GetKeyDown(KeyCode.F) && melee && health.IsAlive()) {
			targetDamage.TakeDamage(100f);

			if (!targetHealth.IsAlive()) {
				SetMelee(false);
			}
		}
	}

	void FixedUpdate () {
		float x = Input.GetAxisRaw("Horizontal");

		if (Input.GetButton("Jump") && grounded) {
			grounded = false;
			rb.AddForce(new Vector3(0f, 4f, 0f), ForceMode.Impulse);
		}
		Move(x);
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.name == "Ground") {
			grounded = true;
		}
	}

	void Move(float x) {
		movement.Set(x, 0f, 0f);
		movement = movement * speed * Time.deltaTime;
		rb.MovePosition(transform.position + movement);
	}

	public void SetMelee(bool m) {
		melee = m;
	}

	public void SetTarget(GameObject go) {
		target = go;
		targetHealth = target.GetComponent<Health>();
		targetDamage = target.GetComponent<Damage>();
	}
}
