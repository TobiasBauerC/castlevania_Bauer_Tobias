using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	Animator animator;
	character_scr player;

	public float lifeTime;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player").GetComponent<character_scr> ();

		if (lifeTime <= 0) {
			lifeTime = 0.25f;
			Debug.LogWarning ("Changing lifeTime to: " + lifeTime);
		}

		Destroy (gameObject, lifeTime);
			
	}//end void start()
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D c)
	{

		if (c.gameObject.tag == "Candles") 
		{
			SoundManager.instance.SoundCaller ("SFXCandleHit");
			GameManager.instance.score += 1;
			Destroy (gameObject);
			Destroy (c.gameObject);
		}

		if (c.gameObject.tag == "Enemy") 
		{
			SoundManager.instance.SoundCaller ("SFXEnemyDie");
			GameManager.instance.score += 20;
			Destroy (c.gameObject);
			Destroy (gameObject);
		}

	}

}


/*
 character_scr player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag ("Player").GetComponent<character_scr> ();

		if (!healthBar)
			Debug.LogError ("No health bar found");
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthBar.value = player.healthUpdate ();
	}
 */