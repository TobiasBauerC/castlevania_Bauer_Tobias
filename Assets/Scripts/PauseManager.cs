using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

	private static bool _paused = false;

	public Transform Canvas_Pause;
	public Button quitBtn;

	void Start()
	{
		if (quitBtn)
			quitBtn.onClick.AddListener (GameManager.instance.MainMenu);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
			paused = togglePause();
	}

	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Canvas_Pause.gameObject.SetActive (false);
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Canvas_Pause.gameObject.SetActive (true);
			Time.timeScale = 0f;
			return(true);    
		}
	}

	public static bool paused
	{ 
		get { return _paused; }
		set { _paused = value; }

	}
}