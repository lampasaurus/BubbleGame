using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnInput : MonoBehaviour {
    public float speed;
    Vector3 right = new Vector3(0, 0, 1.0f);
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            this.transform.Rotate(right * speed);
        }
        if (Input.GetKey("d")) {
            this.transform.Rotate(right * -speed);
        }
    }
}
