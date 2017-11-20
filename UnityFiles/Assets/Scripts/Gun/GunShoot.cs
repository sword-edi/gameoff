using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour {
	public float shootDelay = 0.2f;
	public float baseDamage = 10f;
	public GameObject aim;
	float shootSpeed;
	float timer;
	float timer2;
	float range;
	bool isShooting;
	Light fire;
	LineRenderer gunShot;
	AudioSource gunSound;
	LayerMask player;
	LayerMask shootable;
	Ray shootRay;
	RaycastHit shootHit;
	bool hitSomething;
	bool soundPlaying;

	// Use this for initialization
	void Start () {
		fire = GetComponent<Light>();
		gunShot = GetComponent<LineRenderer>();
		gunSound = GetComponent<AudioSource>();
		shootSpeed = 0.05f;
		timer = 0f;
		isShooting = false;
		player = LayerMask.GetMask("Player");
		shootable = LayerMask.GetMask("Enemy");
		range = 5.5f;
		hitSomething = false;
		soundPlaying = false;
	}

	public void SetShooting(bool s) {
		isShooting = s;
	}
	
	// Update is called once per frame
	void Update () {

		if (isShooting) {
			Shoot();
			timer += Time.deltaTime;
			timer2 += Time.deltaTime;
		}

		if (timer >= shootDelay) {
			timer = 0;
			isShooting = false;
		}

		if (timer2 >= shootSpeed) {
			fire.enabled = false;
			gunShot.enabled = false;
		}

		if (timer2 >= shootDelay) {
			timer2 = 0;
			hitSomething = false;
			soundPlaying = false;
		}
	}

	public void Shoot() {
		if (timer2 < shootSpeed) {
			fire.enabled = true;
			shootRay.origin = transform.position;
			Vector3 aimPosition = aim.transform.position;
			aimPosition.z = -0.16667f;
			shootRay.direction = aimPosition - transform.position;
			gunShot.enabled = true;
			gunShot.SetPosition(0, transform.position);

			if (Physics.Raycast(shootRay, out shootHit, range, shootable | player)) {
				gunShot.SetPosition(1, shootHit.point);
				GameObject target = shootHit.collider.gameObject;
				Damage dmg = target.GetComponent<Damage>();

				if (!hitSomething && dmg != null) {
					hitSomething = true;
					dmg.TakeDamage(baseDamage);
				}
			} else {
				gunShot.SetPosition(1, shootRay.origin + shootRay.direction * range);
			}
			if (!soundPlaying) {
				gunSound.Play();
				soundPlaying = true;
			}
		}
	}
}
