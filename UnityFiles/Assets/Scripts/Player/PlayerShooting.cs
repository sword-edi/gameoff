using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public float range = 100f;
    public float delayBetweenShots = 2000f;
    public float effectsDuration = 0.2f;

    GameObject crosshair;
    Ray shootRay;
    RaycastHit shootHit;
    float timer;
    Light gunLight;
    LineRenderer gunLine;

	// Use this for initialization
	void Start ()
    {
        timer = 0f;
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= delayBetweenShots && Input.GetButton("Fire1"))
        {
            Shoot();
        }

        if (timer >= delayBetweenShots * effectsDuration)
        {
            DisableEffects();
        }
    }

    void Shoot()
    {
        timer = 0f;
        gunLight.enabled = true;
        gunLine.enabled = true;

        gunLine.SetPosition(0, this.transform.position);
        gunLine.SetPosition(1, crosshair.transform.position);// * range);
    }

    void DisableEffects()
    {
        gunLight.enabled = false;
        gunLine.enabled = false;
    }
}
