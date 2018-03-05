using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// manages when the player has completed the level
public class LevelComplete : MonoBehaviour {

	public Image m_crossHair; // crosshair

	public Canvas m_canvasLevelComplete; // canvas for level completion

	public EnemyCount enemycount; // enemycount

	public bool m_levelIsComplete; // level is complete bool

	public AudioSource m_audioSource; // audio source
	public AudioClip m_gameCompleteAudio; // game complete audio

	// Use this for initialization
	void Start () {

		m_levelIsComplete = false; // level is not complete

		m_canvasLevelComplete.enabled = false; // canvas is not enabled
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// upon colliding with collider
	void OnTriggerEnter(Collider _collider){

		// when enemy count is 0 and player has collided with the helicopter
		if (enemycount.m_enemiesRemaining == 0 && _collider.transform.tag == "Player") {

			m_levelIsComplete = true; // level is complete

			Time.timeScale = 0; // time stops

			m_crossHair.enabled = false; // cross hair disabled

			m_canvasLevelComplete.enabled = true; // level complete canvas enabled

			m_audioSource.PlayOneShot (m_gameCompleteAudio); // victory audio plays
		}
	}

	// next level function for buttopn
	public void NextLevel(){

		SceneManager.LoadScene ("Scene2"); // goes to scene2
	}

	// back to main menu button
	public void BackToMainMenu(){

		SceneManager.LoadScene ("MainMenu"); // goes to main menu scene
	}
}