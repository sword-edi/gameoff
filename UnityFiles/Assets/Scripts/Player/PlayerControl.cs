using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public GameObject gun;
	public GameObject mouse;

	Rigidbody rb;
	Vector3 movement;
	float speed = 7.5f;
	bool grounded = false;
	Vector3 beforeJump;
	GunShoot shooter;
	Health health;
	bool melee;
	GameObject target;
	Health targetHealth;
	Damage targetDamage;
	float run;
	Animator animator;
	bool lookLeft;
	bool lookRight;
	float crouch;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		health = GetComponent<Health>();
		animator = GetComponent<Animator>();
		melee = false;
		target = null;
		targetHealth = null;
		targetDamage = null;
		lookLeft = false;
		lookRight = true;

		if (gun != null)
			shooter = gun.GetComponent<GunShoot>();
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetButtonDown("Fire1") && health.IsAlive()) {
			shooter.SetShooting(true);
		}

		if (Input.GetKeyDown(KeyCode.F) && melee && health.IsAlive()) {
			targetDamage.TakeDamage(transform.position, 100f);

			if (!targetHealth.IsAlive()) {
				SetMelee(false);
			}
		}

		if ((mouse.transform.position.x - transform.position.x) < 0) {
			if ((int) transform.rotation.eulerAngles.y == 90) {
				transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
				lookLeft = true;
				lookRight = false;
			}
		} else {
			if ((int) transform.rotation.eulerAngles.y == 270) {
				transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
				lookLeft = false;
				lookRight = true;
			}
		}
	}

	void FixedUpdate () {
		float x = Input.GetAxisRaw("Horizontal");

		if (Input.GetButton("Jump") && grounded) {
			grounded = false;
			animator.SetBool("jump", true);
			rb.AddForce(new Vector3(0f, 6f, 0f), ForceMode.Impulse);
		}

		if (grounded) {
			animator.SetBool("crouch", Input.GetKey(KeyCode.C));
		} else {
			animator.SetBool("crouch", false);
		}

		if (animator.GetBool("crouch")) {
			crouch = 0.3f;
		} else {
			crouch = 1f;
		}

		if ((lookLeft && x < 0) || (lookRight && x > 0)) {
			if (lookLeft) {
				animator.SetBool("forwardLeft", true);
				animator.SetBool("backLeft", false);
				animator.SetBool("forwardRight", false);
				animator.SetBool("backRight", false);
			} else {
				if (!animator.GetBool("forwardRight")) {
					animator.SetBool("forwardLeft", false);
					animator.SetBool("backLeft", false);
					animator.SetBool("forwardRight", true);
					animator.SetBool("backRight", false);
				}
			}				

			if (Input.GetKey(KeyCode.LeftShift)) {
				run = 1.5f;
			} else {
				run = 1f;
			}
		} else if (x == 0) {
			animator.SetBool("forwardLeft", false);
			animator.SetBool("backLeft", false);
			animator.SetBool("forwardRight", false);
			animator.SetBool("backRight", false);
		} else {
			run = 1f;
			if (lookLeft && x > 0) {
				animator.SetBool("forwardLeft", false);
				animator.SetBool("backLeft", false);
				animator.SetBool("forwardRight", false);
				animator.SetBool("backRight", true);
			} else {
				animator.SetBool("forwardLeft", false);
				animator.SetBool("backLeft", true);
				animator.SetBool("forwardRight", false);
				animator.SetBool("backRight", false);
			}
		}

		Move(x * run * crouch);
	}

	void OnTriggerEnter(Collider c) {
		//if (c.gameObject.name == "Ground" || c.gameObject.name == "Obstacle") {
		if (c.gameObject.name == "Ground" || c.gameObject.CompareTag("Obstacle")) {
			grounded = true;
			animator.SetBool("jump", false);
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
