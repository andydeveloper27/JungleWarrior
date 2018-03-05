using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// manages what happens upon game completion
public class GameComplete : MonoBehaviour {

	public Image m_crossHair; // crosshair

	public Canvas m_canvasGameComplete; // canvas for game complete

	public EnemyCount enemycount; // enemy count

	public bool m_levelIsComplete; // level is complete

	public AudioSource m_audioSource; // audiosource
	public AudioClip m_gameCompleteAudio; // game complate audio

	// Use this for initialization
	void Start () {

		m_levelIsComplete = false; // level is not complate

		m_canvasGameComplete.enabled = false; // canvas not enabled
	}

	// Update is called once per frame
	void Update () {

	}

	// upon colliding with the trigger
	void OnTriggerEnter(Collider _collider){

		// when enemy count is 0 and the player collides with the helicopter
		if (enemycount.m_enemiesRemaining == 0 && _collider.transform.tag == "Player") {

			m_levelIsComplete = true; // level is now complete

			Time.timeScale = 0; // time is stopped

			m_crossHair.enabled = false; // cross hair disabled

			m_canvasGameComplete.enabled = true; // game complete canvas enabled

			m_audioSource.PlayOneShot (m_gameCompleteAudio); // plays victory audio
		}
	}

	// back to the main menu button
	public void BackToMainMenu(){

		SceneManager.LoadScene ("MainMenu"); // goes back the main menu scene
	}
}
