using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float speed = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Camera.main.transform);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-(speed * Time.deltaTime), 0, 0, Camera.main.transform);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0, Camera.main.transform);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -(speed * Time.deltaTime), 0, Camera.main.transform);
        }
    }
}
