using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class character_scr : MonoBehaviour {

	Rigidbody2D rb;// setting rigidbody2d
	Animator anim;// setting animator

	//used to change size of healthbar size

	int maxHealth = 10;
	int curHealth = 10;

	public float speed;// store the characters speed
	public float jumpForce;//store the characters jump strength
	public bool isGrounded;// T/F if the player is on the ground
	public LayerMask isGroundLayer;// layer things have to be on in order to be jumped off of
	public Transform groundCheck;// what the checker for the ground is
	public float groundCheckRadius;// distance arouond for jump

	//Handle Projectile Instantation (aka create)
	public Transform whipSpawnPoint;
	public projectile whipPrefab;
	public bool isWalking;
	public bool isFire;

	public bool isFacingLeft;

	public Transform knifeSpawn;
	public Projectile_Knife projectileKnifePrefab;
	public float knifeSpeed;

	public int health;
	bool jumpAtk;

	public enum actions : int//for all of posible states for animations
	{
		Idle,//0
		Walk,//1
		Crouch,//2
		Attack,//3
		Crouch_Attack,//4
		Jump//5
	};
	public int currentAction;// stores the state that the player could be in for the animations

	//
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();// getting rigidbody componenet
		anim = GetComponent<Animator> ();// getting animator component
		//checking and setting all variables
		if (!rb) {
			Debug.LogWarning ("No Rigidbody2D found.");
		}//end if(!rb)
		if (!anim) {
			Debug.LogWarning ("No Animator found.");
		}//end if(!rb)

		if (speed <= 0) {
			speed = 5.0f;
			Debug.LogWarning ("Default speeding to " + speed);
		}

		if (jumpForce >= 0) {
			jumpForce = 5.0f;
			Debug.LogWarning ("Default jumping to " + jumpForce);
		}
		if(groundCheckRadius >= 0) {
			groundCheckRadius = 0.2f;
			Debug.LogWarning ("Default groundCheckRadius to " + groundCheckRadius);
		}
		if (!groundCheck) {
			Debug.LogWarning ("No groundCheck found.");
		}
		if (isWalking) {
			isWalking = false;
		}
		if (isFire)
			isFire = false;

		if (knifeSpeed <= 0) {
			knifeSpeed = 5.0f;
		}

		if (health <= 0) {
			health = 10;
		}
		//checking and setting all variables


	}//end void start()
	
	// Update is called once per frame
	void Update () {

		if (PauseManager.paused)
			return;

		anim.SetInteger ("state", currentAction);

		//Walking
		float moveValue = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 (speed * moveValue, rb.velocity.y);//makes the speed
		//Walking
		//Jumping
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, isGroundLayer);
		if (Input.GetButtonDown ("Jump") && isGrounded) 
		{
			SoundManager.instance.SoundCaller ("SFXJump");
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
		//Jumping
		//All animation calls

		if (!Input.anyKey)
			currentAction = (int)actions.Idle;

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("CanJump", true);	
			jumpAtk = true;
		} else if (isGrounded) {
			anim.SetBool ("CanJump", false);
			jumpAtk = false;
		}

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {		//Moving 
			anim.SetBool("Walking", true);
			isWalking = true;														//Moving 	
		} else {	
			anim.SetBool("Walking", false);
			isWalking = false;														//Moving 
		}																			//Moving 

		if ((Input.GetKeyDown (KeyCode.LeftShift) && isWalking == false && isFire == false && isGrounded == true) || (Input.GetKeyDown (KeyCode.RightShift) && isWalking == false && isFire == false && isGrounded == true)) {
			anim.SetBool ("Attack", true);
			Invoke ("whip", 0.5f);
			isFire = true;
		} else if (isFire == false) {
			anim.SetBool ("Attack", false);
		}
		if (Input.GetKey (KeyCode.C))
			currentAction = (int)actions.Crouch;
		if ((Input.GetKey (KeyCode.C) && Input.GetKeyDown (KeyCode.LeftShift)) || (Input.GetKey (KeyCode.C) && Input.GetKeyDown (KeyCode.RightShift)))
			anim.SetBool ("CanCrouchAttack", true);
		else 
			anim.SetBool ("CanCrouchAttack", false);
		
		
		//All animation calls

		if (Input.GetKeyDown (KeyCode.V))
			fire ();

		if ((isFacingLeft && moveValue < 0) || (!isFacingLeft && moveValue > 0))
			flip ();

		if (health <= 0) 
		{
			SoundManager.instance.SoundCaller ("MusicGameOver");
			SceneManager.LoadScene ("GameOverScreen");
		}

		curHealth = health;

	}//end void update()

	void whip(){
		SoundManager.instance.SoundCaller ("SFXPlayerWhip");
		isFire = false;
		projectile temp = Instantiate (whipPrefab, whipSpawnPoint.transform.position, whipSpawnPoint.rotation);
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Enemy") {
			SoundManager.instance.SoundCaller ("SFXPlayerDamage");
			health--;
		}
		else if (c.gameObject.tag == "Points100") {
			GameManager.instance.score += 100;
			SoundManager.instance.SoundCaller ("SFXPlayerCollectable");
			Destroy (c.gameObject);
		}
		else if (c.gameObject.tag == "Points400") {
			GameManager.instance.score += 400;
			SoundManager.instance.SoundCaller ("SFXPlayerCollectable");
			Destroy (c.gameObject);
		}
		else if (c.gameObject.tag == "Points700") {
			GameManager.instance.score += 700;
			SoundManager.instance.SoundCaller ("SFXPlayerCollectable");
			Destroy (c.gameObject);
		}
		else if (c.gameObject.tag == "Points1000") {
			GameManager.instance.score += 1000;
			SoundManager.instance.SoundCaller ("SFXPlayerCollectable");
			Destroy (c.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "Colectables") {
			GameManager.instance.score += 5;
			SoundManager.instance.SoundCaller ("SFXPlayerCollectable");
			Destroy (c.gameObject);
		}
		else if (c.gameObject.tag == "HeartSmall") {
			GameManager.instance.score += 5;
			SoundManager.instance.SoundCaller ("SFXPlayerCollectable");
			Destroy (c.gameObject);
		}
		else if (c.gameObject.tag == "HeartBig") {
			GameManager.instance.score += 10;
			SoundManager.instance.SoundCaller ("SFXPlayerCollectable");
			Destroy (c.gameObject);
		}
	}

	void flip(){
		//change the direction
		isFacingLeft = !isFacingLeft;
		//create a variable the checks the x location
		Vector3 scaleFactor = transform.localScale;
		//invert the x scale so that your character changes the direction he's facing
		scaleFactor.x *= -1;
		//update the scalefactor so that it will always change the direction properly
		transform.localScale = scaleFactor;
	}

	void fire()
	{
		if (GameManager.instance.knifeCount > 0) 
		{
			Projectile_Knife temp = Instantiate (projectileKnifePrefab, knifeSpawn.transform.position, knifeSpawn.rotation);

			if (isFacingLeft) 
			{
				temp.speed = knifeSpeed;
			} 
			else if (!isFacingLeft) 
			{
				temp.speed = -knifeSpeed;
			}

			SoundManager.instance.SoundCaller ("SFXThrow");
			GameManager.instance.knifeCount--;
		}
	}//end fire()

	public float healthUpdate()
	{
		return ((float)curHealth / (float)maxHealth) * 100;
	}


}




