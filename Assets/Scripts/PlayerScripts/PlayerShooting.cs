using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// manages player shooting
public class PlayerShooting : MonoBehaviour {

	public PauseMenu pausemenu; // pausemenu
	public LevelComplete levelcomplete; // level complete

	public Camera m_fpsCam; // fps cam

	public AudioSource m_audioSource; // audio source

	public AudioClip m_shootingSound; // shooting sound
	public AudioClip m_emptyGunSound; // empty gun sound

	public GameObject m_bulletEmitter; // bullet emitter
	public GameObject m_bullet; // bullet

	public ParticleSystem m_muzzleFlash; // muzzleflash

	public Text m_bulletCounter; // bullet counter

	public float m_bulletsRemaining; // bullets remaining
	public float m_bulletDamage; // bullet damage
	public float m_range; // range

	private float m_bulletSpeed; // bullet speed

	private float m_nextFire; // next fire
	private float m_fireRate; // fire rate

	// Use this for initialization
	void Start () {

		m_nextFire = 0f; // nextfire = 0
		m_fireRate = 1f; // fire rate - 1

		//m_audioSource = GetComponent<AudioSource> ();

		m_bulletSpeed = 2000.0f; // bullet speed

		m_bulletDamage = 20f; // bullet damage

		m_bulletsRemaining = 4f; // bullets remaining

		m_range = 100f; // range
	}
	
	// Update is called once per frame
	void Update () {

		// bullet counter converted to text
		m_bulletCounter.GetComponent<Text> ().text = m_bulletsRemaining.ToString ();

		// checks for mouse click, bullets remaining, fire rate, game is not paused, level has not been complete,
		// and time is running at 1
		if (Input.GetMouseButtonDown (0) && m_bulletsRemaining > 0 && Time.time > m_nextFire &&
			!pausemenu.m_gameIsPaused && !levelcomplete.m_levelIsComplete && Time.timeScale == 1) {

			m_nextFire = Time.time + m_fireRate; // delay with the shooting

			Shoot (); // shoot function
		}

		// when mouse is down and no bullets
		if (Input.GetMouseButtonDown (0) && m_bulletsRemaining == 0) {

			m_audioSource.PlayOneShot (m_emptyGunSound); // empty gun sound
		}
	}

	// shoot function
	private void Shoot(){

		RaycastHit hit; // raycast

		// ray cast from camera with set range
		if (Physics.Raycast (m_fpsCam.transform.position, m_fpsCam.transform.forward, out hit, m_range)) {

			EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth> (); // enemy target

			// if enemy is available
			if (enemy != null) {

				enemy.TakeDamage (m_bulletDamage); // take damage from enemy
			}
		}

		m_bulletsRemaining--; // bullet decrement

		m_muzzleFlash.Play (); // muzzle flash play

		m_audioSource.PlayOneShot (m_shootingSound); // audio play

		BulletSpawn (); // spawns bullet
	}

	// bullet spawning function
	private void BulletSpawn(){

		GameObject temporaryBulletHandler; // temp bullet

		// instantiates bullet
		temporaryBulletHandler = Instantiate (m_bullet, m_bulletEmitter.transform.position, m_bulletEmitter.transform.rotation) 
			as GameObject;

		Rigidbody temporaryBulletRigidbody; // temp rigidbody

		temporaryBulletRigidbody = temporaryBulletHandler.GetComponent<Rigidbody> (); // sets to a rigidbody

		temporaryBulletRigidbody.AddForce (transform.forward * m_bulletSpeed); // adds force to bullet

		Destroy (temporaryBulletHandler, 2.0f); // destroys bullet after so long
	}
}