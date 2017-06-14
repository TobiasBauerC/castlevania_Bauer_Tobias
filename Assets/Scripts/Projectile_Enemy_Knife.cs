using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Enemy_Knife : MonoBehaviour {

	public float speed;
	public float lifeTime;

	character_scr player;

	// Use this for initialization
	void Start () {

		if (lifeTime <= 0) 
			lifeTime = 1.0f;
			
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);

		Destroy (gameObject, lifeTime);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag != "Enemy") 
		{
			Destroy (gameObject);
		}
	}
}
