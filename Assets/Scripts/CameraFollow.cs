﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float xMax;
	public float yMax;

	public float xMin;
	public float yMin;

	public Transform target;

	// Use this for initialization
	void Start () {

		target = GameObject.Find ("Simon(Clone)").transform;

	}
	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin,yMax), transform.position.z);

	}
}
