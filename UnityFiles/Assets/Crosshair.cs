using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Crosshair : MonoBehaviour {
    public GameObject shot;
    public ThirdPersonCharacter player;

    float a;
    Vector3 v;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        bool crouching = player.isCrouched();
        Vector3 p = new Vector3();
        Vector3 o = player.transform.position;
        o.z = 0f;
        o.y += 0.8f;
        Camera c = Camera.main;
        Vector3 mousePos = new Vector3();
        mousePos.x = Input.mousePosition.x - o.x;
        mousePos.y = Input.mousePosition.y - o.y;
        p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane - c.transform.position.z - 1f));
        v = p - o;
        v = this.transform.InverseTransformDirection(v);
        a = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        this.transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * a) * 1.5f, Mathf.Sin(Mathf.Deg2Rad * a) * 1.5f, 0f) + o + new Vector3(0f, .3f, 0f);

        if (crouching)
        {
            this.transform.position -= new Vector3(0f, 0.75f, 0f);
        }
        
        bool fire = Input.GetKey(KeyCode.Mouse0);

        if (fire)
        {
           /* Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {*/
                GameObject s = Instantiate(shot);
                s.name = "ShotInstance";
                s.transform.position = o;
            //}
        }
    }
}
