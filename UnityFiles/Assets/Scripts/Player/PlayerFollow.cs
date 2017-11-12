using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public float smoothing = 5f;
    GameObject mouseLayer;
    GameObject player;
    Vector3 offset;

    // Use this for initialization
    void Start () {
        mouseLayer = GameObject.FindGameObjectWithTag("MouseLayer");
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
        //Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        mouseLayer.transform.position = player.transform.position;
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing * Time.deltaTime);
    }
}
