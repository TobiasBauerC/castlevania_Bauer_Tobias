using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

	public Button startBtn;
	public Button quitBtn;
	public Button credBtn;

	// Use this for initialization
	void Start () 
	{
		if (startBtn) 
		{
			startBtn.onClick.AddListener (GameManager.instance.StartGame);
		}

		if (quitBtn)
		{
			quitBtn.onClick.AddListener (GameManager.instance.QuitGame);
		}

		if (credBtn) 
		{
			credBtn.onClick.AddListener (GameManager.instance.Credits);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}