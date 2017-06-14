using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Canvas_Manager : MonoBehaviour {

	public Slider healthBar;

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
}
