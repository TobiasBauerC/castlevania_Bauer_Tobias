using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Knife : MonoBehaviour {

	public float speed;
	public float lifeTime;

	character_scr player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player").GetComponent<character_scr> ();

		if (lifeTime <= 0) {
			lifeTime = 1.0f;
		}

		if (player.isFacingLeft == true) {
			GetComponent<Rigidbody2D> ().velocity = 
			new Vector2 (speed, 0);
			
			Destroy (gameObject, lifeTime);
		} 
		else 
		{
			GetComponent<Rigidbody2D> ().velocity = 
				new Vector2 (speed, 0);

			Vector3 scaleFactor = transform.localScale;
			//invert the x scale so that your character changes the direction he's facing
			scaleFactor.x *= -1;
			//update the scalefactor so that it will always change the direction properly
			transform.localScale = scaleFactor;

			Destroy (gameObject, lifeTime);
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (gameObject.tag == "Projectile")
		{
			if (c.gameObject.name != "Simon" && c.gameObject.tag != "Colectables") {
				Destroy (gameObject);
			}

			if (c.gameObject.tag == "Enemy") {
				SoundManager.instance.SoundCaller ("SFXEnemyDie");
				GameManager.instance.score += 20;
				Destroy (gameObject);
				Destroy (c.gameObject);
			}
		}
	}
}
