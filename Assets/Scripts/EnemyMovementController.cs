using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

	//Handle Projectile Instantation (aka create)
	public Transform projectileSpawnPoint;
	public Projectile_Enemy_Knife projectilePrefab;

	//Handles projectile mechanic
	public float projectileFireRate;

	public int id;

	public float enemySpeed = -3f;
	public float flipTime = 2f;

	// Use this for initialization
	void Start () {

		if (id < 0)
			id = 0;
		if (id == 1) 
		{
			if (!projectileSpawnPoint) {
				Debug.LogError ("No projectileSpawnPoint");
			}
			if (!projectilePrefab) {
				Debug.LogError ("No projectilePrefab");
			}
			if (projectileFireRate <= 0) {
				projectileFireRate = 2.0f;
			}
		}

		InvokeRepeating ("flip", flipTime, flipTime);

		if (id == 1) //bat stuff
		{
			InvokeRepeating ("fire", projectileFireRate, projectileFireRate);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (enemySpeed * Time.deltaTime, 0, 0);
	}

	void flip(){
		enemySpeed *= -1f;
		Vector3 scaleFactor = transform.localScale;
		scaleFactor.x *= -1;
		transform.localScale = scaleFactor;
	}

	void fire()
	{
		Projectile_Enemy_Knife temp = 
			Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
	}//end fire()
}

