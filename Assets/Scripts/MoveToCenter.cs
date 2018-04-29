using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour {
    GameObject center;
    public float speed;
    Vector3 dir;

	// Use this for initialization
	void Start () {

        center = GameObject.FindWithTag("Player");
        dir = gameObject.transform.position - center.transform.position;
        dir = dir.normalized;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += dir * speed;
	}
}
