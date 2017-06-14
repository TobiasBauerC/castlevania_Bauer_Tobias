using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	public int spawnLocation;

	// Use this for initialization
	void Awake () 
	{
		//Pause.paused = false; //pause screen staring as not paused

		PauseManager.paused = false;
		Time.timeScale = 1f;

		if (spawnLocation < 0)
			spawnLocation = 0;

		Debug.Log ("Hello World! 0");

		// call spawnplayer from gamemanager
		GameManager.instance.spawnPlayer(spawnLocation);

		//score things
		GameManager.instance.scoreText = GameObject.Find ("Text_Score").GetComponent<Text> ();
		GameManager.instance.scoreText.text = "Score - " + GameManager.instance.score;

		GameManager.instance.knifeCountText = GameObject.Find ("Knife_Count_Text").GetComponent<Text> ();
		GameManager.instance.knifeCountText.text = "X " + GameManager.instance.knifeCount;
	}


}