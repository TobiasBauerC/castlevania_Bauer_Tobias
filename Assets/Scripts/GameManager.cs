using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // used for going between scenes/levels
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	character_scr character;

	public GameObject playerPrefab;

	static GameManager _instance = null; // keeps a reference to the instance. Creates a class variable that is exesible everywhere. So it is private and needs getters and setters

	int _score;
	int _knifeCount;

	//keep track of the textbox
	public Text scoreText;
	public Text knifeCountText;

	// Use this for initialization
	void Start () 
	{
		if (instance)
			DestroyImmediate (gameObject); // destroys the new one that was just created 
		else 
		{
			instance = this;

			DontDestroyOnLoad (this);
		}

		character = GetComponent<character_scr> ();

		//assign a starting score
		score = 0;
		knifeCount = 10;

		SoundManager.instance.SoundCaller ("MusicTitle");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (SceneManager.GetActiveScene ().name == "castlevania_lvl1") 
			{
				SoundManager.instance.SoundCaller ("MusicTitle");
				SceneManager.LoadScene ("Title_Screen");
			}
			else if(SceneManager.GetActiveScene().name == "GameOverScreen")
			{
				SoundManager.instance.SoundCaller ("MusicTitle");
				SceneManager.LoadScene ("Title_Screen");
			}			
			else if(SceneManager.GetActiveScene().name == "Title_Screen")
				StartGame(); // changes to another scene called what's in the brackets
			else if(SceneManager.GetActiveScene().name == "Credits")
				SceneManager.LoadScene ("Title_Screen");
		}


	}

	//gets called to  start game
	public void StartGame()
	{
		// loads level1 scene
		SoundManager.instance.SoundCaller("SFXPlayerStartGame");
		SoundManager.instance.SoundCaller ("MusicLevel1");
		SceneManager.LoadScene ("castlevania_lvl1");
	}

	//gets called to quit game
	public void QuitGame()
	{
		// loads level1 scene			
		SoundManager.instance.SoundCaller("SFXPlayerStartGame");
		Debug.Log("Quit Game");

		Application.Quit ();
	}

	public void Credits()
	{
		SoundManager.instance.SoundCaller("SFXPlayerStartGame");
		SceneManager.LoadScene ("Credits");
	}

	public void MainMenu()
	{
		SoundManager.instance.SoundCaller("SFXPlayerStartGame");
		SoundManager.instance.SoundCaller ("MusicTitle");
		SceneManager.LoadScene ("Title_Screen");
	}


	//called when 'character' is spawned
	public void spawnPlayer(int spawnLocation)
	{


		//requires spawnpoint to be named (SceneName)_(number)
		// - scene_01_0
		string spawnPointName = SceneManager.GetActiveScene().name + "_" + spawnLocation;

		if(spawnPointName == "castlevania_lvl1_0")
			Debug.Log ("Hello World! 1");

		//find the location to spawn the character at
		Transform spawnPointTransform = GameObject.Find(spawnPointName).GetComponent<Transform>();

		//Instansiate (create) 'character' GameObject
		Instantiate(playerPrefab, spawnPointTransform.position, spawnPointTransform.rotation);
	}

	public static GameManager instance
	{
		get{ return _instance; }
		set{ _instance = value; }
		//gets and setting in Unity programing form 0_0
	}

	public int score
	{
		get{ return _score; }
		set{ _score = value; 
			if(scoreText)
				scoreText.text = "Score - " + score;}
	}

	public int knifeCount
	{
		get{ return _knifeCount; }
		set{ _knifeCount = value; 
			if(knifeCountText)
				knifeCountText.text = "X " + knifeCount;}
	}
}


/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // used for going between scenes/levels
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	character character;

	public GameObject playerPrefab;

	static GameManager _instance = null; // keeps a reference to the instance. Creates a class variable that is exesible everywhere. So it is private and needs getters and setters

	int _score;

	//keep track of the textbox
	public Text scoreText;

	//game music

	// Use this for initialization
	void Start () 
	{
		if (instance)
			DestroyImmediate (gameObject); // destroys the new one that was just created 
		else 
		{
			instance = this;

			DontDestroyOnLoad (this);
		}

		character = GetComponent<character> ();

		//assign a starting score
		score = 0;

		SoundManager.instance.MusicCaller ("Title");

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (SceneManager.GetActiveScene ().name == "scene_01") 
			{
				SceneManager.LoadScene ("TitleScreen");
				SoundManager.instance.MusicCaller ("Title");
			}
			else if(SceneManager.GetActiveScene().name == "GameOverScreen")
			{
				SceneManager.LoadScene ("TitleScreen");
				SoundManager.instance.MusicCaller ("Title");
			}			
			else if(SceneManager.GetActiveScene().name == "TitleScreen")
				StartGame(); // changes to another scene called what's in the brackets
		}


	}

	//gets called to  start game
	public void StartGame()
	{
		// loads level1 scene
		SceneManager.LoadScene ("scene_01");
		SoundManager.instance.MusicCaller ("Level1");
	}

	//gets called to quit game
	public void QuitGame()
	{
		// loads level1 scene
		Debug.Log("Quit Game");

		Application.Quit ();
	}


	//called when 'character' is spawned
	public void spawnPlayer(int spawnLocation)
	{
		//requires spawnpoint to be named (SceneName)_(number)
		// - scene_01_0
		string spawnPointName = SceneManager.GetActiveScene().name + "_" + spawnLocation;

		//find the location to spawn the character at
		Transform spawnPointTransform = GameObject.Find(spawnPointName).GetComponent<Transform>();

		//Instansiate (create) 'character' GameObject
		Instantiate(playerPrefab, spawnPointTransform.position, spawnPointTransform.rotation);
	}

	public static GameManager instance
	{
		get{ return _instance; }
		set{ _instance = value; }
		//gets and setting in Unity programing form 0_0
	}

	public int score
	{
		get{ return _score; }
		set{ _score = value; 
			if(scoreText)
				scoreText.text = "Score " + score;}
	}
}

*/
