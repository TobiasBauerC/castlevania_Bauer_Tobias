using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	static SoundManager _instance = null;

	public AudioSource sfxSource;
	public AudioSource musicSource; 
	public AudioSource enemySource;

	public AudioClip TitleMusic;
	public AudioClip Level1Music;
	public AudioClip GameOverMusic;
	public AudioClip SFXCandleHit;
	public AudioClip SFXEnemyBossDie;
	public AudioClip SFXEnemyDie;
	public AudioClip SFXJump;
	public AudioClip SFXPlayerCollectable;
	public AudioClip SFXPlayerDamage;
	public AudioClip SFXPlayerStartGame;
	public AudioClip SFXPlayerWhip;
	public AudioClip SFXThrow;

	// Use this for initialization
	void Start () {
		if (instance)
			DestroyImmediate (gameObject); // destroys the new one that was just created 
		else 
		{
			instance = this;

			DontDestroyOnLoad (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SoundCaller(string i)
	{
		if (i == "MusicTitle")
			playMusic (TitleMusic);
		else if (i == "MusicLevel1")
			playMusic (Level1Music);
		else if (i == "MusicGameOver")
			playMusic (GameOverMusic);
		else if (i == "SFXCandleHit")
			playSFX (SFXCandleHit);
		else if (i == "SFXEnemyBossDie")
			playEnemySFX (SFXEnemyBossDie);
		else if (i == "SFXEnemyDie")
			playEnemySFX (SFXEnemyDie);
		else if (i == "SFXPlayerCollectable")
			playSFX (SFXPlayerCollectable);
		else if (i == "SFXPlayerDamage")
			playSFX (SFXPlayerDamage);
		else if (i == "SFXPlayerStartGame")
			playSFX (SFXPlayerStartGame);
		else if (i == "SFXPlayerWhip")
			playSFX (SFXPlayerWhip);
		else if (i == "SFXJump")
			playSFX (SFXJump);
		else if (i == "SFXThrow")
			playSFX (SFXThrow);
	}

	public void playSFX(AudioClip clip, float volume=1.0f)
	{
		//assign the volume
		sfxSource.volume = volume;

		//assign the clip
		sfxSource.clip = clip;

		//play the audio
		sfxSource.Play();
	}

	void playMusic(AudioClip clip, float volume=0.1f)
	{
		//assign the volume
		musicSource.volume = volume;

		//assign the clip
		musicSource.clip = clip;

		//play the audio
		musicSource.Play();
	}
		
	public void playEnemySFX(AudioClip clip, float volume=1.0f)
	{
		//assign the volume
		enemySource.volume = volume;

		//assign the clip
		enemySource.clip = clip;

		//play the audio
		enemySource.Play();
	}

	public static SoundManager instance
	{
		get{ return _instance; }
		set{ _instance = value; }
		//gets and setting in Unity programing form 0_0
	}
}



/*

static SoundManager _instance = null;

	public AudioSource sfxSource;
	public AudioSource musicSource; 
	public AudioSource enemySource;

	public AudioClip TitleMusic;
	public AudioClip MarioMusic;
	public AudioClip GameOverMusic;

	// Use this for initialization
	void Start () {
		if (instance)
			DestroyImmediate (gameObject); // destroys the new one that was just created 
		else 
		{
			instance = this;

			DontDestroyOnLoad (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playSFX(AudioClip clip, float volume=1.0f)
	{
		//assign the volume
		sfxSource.volume = volume;

		//assign the clip
		sfxSource.clip = clip;

		//play the audio
		sfxSource.Play();
	}

	public void playEnemySFX(AudioClip clip, float volume=1.0f)
	{
		//assign the volume
		enemySource.volume = volume;

		//assign the clip
		enemySource.clip = clip;

		//play the audio
		enemySource.Play();
	}

	void playMusic(AudioClip clip, float volume=0.1f)
	{
		//assign the volume
		musicSource.volume = volume;

		//assign the clip
		musicSource.clip = clip;

		//play the audio
		musicSource.Play();
	}

	//best way to do this VVVVVVVVV
	public void MusicCaller(string i)
	{
		if (i == "Title")
			playMusic (TitleMusic);
		else if (i == "Level1")
			playMusic (MarioMusic);
		else if (i == "GameOver")
			playMusic (GameOverMusic);
			
	}

	public static SoundManager instance
	{
		get{ return _instance; }
		set{ _instance = value; }
		//gets and setting in Unity programing form 0_0
	}

*/