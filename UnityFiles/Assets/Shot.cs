using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Shot : MonoBehaviour
{
    Vector3 v;
    float a;
    public ThirdPersonCharacter player;
    public GameObject crosshair;

    void OnCollisionEnter(Collision obj)
    {
        if (this.name != "Shot")
        {
            Destroy(this.gameObject, .5f);
        }
    }

    // Use this for initialization
    void Start ()
    {
        bool crouching = player.isCrouched();
        v = crosshair.transform.position - this.transform.position;
        //v = this.transform.InverseTransformDirection(v);
        a = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        this.transform.Rotate(0f, a, 0f);
        this.transform.position = player.transform.position + new Vector3(Mathf.Cos(Mathf.Deg2Rad * a) * 0.9f, Mathf.Sin(Mathf.Deg2Rad * a) * 0.9f, 0f) + new Vector3(0f, .8f, 0f); ;
        ConstantForce constantForce = GetComponent<ConstantForce>();
        constantForce.force = 1000f * new Vector3(Mathf.Cos(Mathf.Deg2Rad * a), Mathf.Sin(Mathf.Deg2Rad * a), 0f);
        Debug.Log("angle = " + a.ToString()  + "°");

        if (crouching)
        {
            this.transform.position -= new Vector3(0f, 0.75f, 0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
    }
}
