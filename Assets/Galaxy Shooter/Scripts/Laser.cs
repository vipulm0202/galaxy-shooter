﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= 6) {
            DestroyLaser();
        }		
	}

    public void DestroyLaser() {
        GameObject obj = transform.parent != null ? transform.parent.gameObject : this.gameObject;
        Destroy(obj);
    }
}
