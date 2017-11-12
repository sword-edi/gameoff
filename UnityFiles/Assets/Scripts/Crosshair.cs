using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Crosshair : MonoBehaviour {

    float camRayLength = 100f;
    int mouseLayer;
    GameObject player;
    float a;
    Vector3 v;
    Vector3 offset = new Vector3(0f, 0.8f, 0f);
    float maxDistance = 2f;

    // Use this for initialization
    void Start () {
        mouseLayer = LayerMask.GetMask("MouseLayer");
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.mousePosition.x - (Screen.width / 2);
        float y = Input.mousePosition.y - (Screen.height / 2);
        float h1 = Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f));
        float ratio;
        
        if (h1 > maxDistance)
        {
            ratio = maxDistance / h1;
        } else
        {
            ratio = h1 / maxDistance;
        }
        transform.position = new Vector3(x * ratio, y * ratio, 0f) + offset;
    }
}
