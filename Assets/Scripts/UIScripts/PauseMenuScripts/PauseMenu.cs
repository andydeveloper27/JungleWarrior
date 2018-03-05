using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// pause menu manager script
public class PauseMenu : MonoBehaviour {

	public bool m_gameIsPaused; // game is paused bool

	public GameObject m_pauseMenuUI; // pause menu UI
	public GameObject m_musicMenuUI; // main menu UI

	public AudioSource m_audioSource; // audio source

	public AudioClip m_track1; // track 1
	public AudioClip m_track2; // track 2
	public AudioClip m_track3; // track 3
	public AudioClip m_track4; // track 4

	public Image m_crossHair; // crosshair

	// Use this for initialization
	void Start () {
		
		m_gameIsPaused = false; // game is not paused
	}
	
	// Update is called once per frame
	void Update () {

		// when the player presses escape or P
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Escape)) {

			// if game is already paused
			if (m_gameIsPaused) {

				ResumeGame (); // resume game

				m_crossHair.enabled = true; // enable crosshair again
			} 
			else {

				Cursor.visible = true; // makes sure cursor is visible

				PauseGame (); // pause game

				m_crossHair.enabled = false; // disable crosshair
			}
		}
	}

	// pause game
	void PauseGame(){

		m_pauseMenuUI.SetActive (true); // pause menu active

		Time.timeScale = 0; // time is not running

		m_gameIsPaused = true; // game is paused
	}

	// resume game
	public void ResumeGame(){

		m_crossHair.enabled = true; // enable crosshair

		m_pauseMenuUI.SetActive (false); // pause menu not enabled
		m_musicMenuUI.SetActive (false); // music menu not enabled

		Time.timeScale = 1; // time is running again

		m_gameIsPaused = false; // game is not paused
	}

	// quit game function
	public void QuitGame(){

		SceneManager.LoadScene ("MainMenu"); // loads main menu
	}

	// music menu
	public void MusicMenu(){
		
		m_pauseMenuUI.SetActive (false); // pause menu is not enabled
		m_musicMenuUI.SetActive (true); // music menu enabled
	}

	// resume game in music menu
	public void ResumeInMusicMenu(){

		m_crossHair.enabled = true; // cross hair enabled again

		m_pauseMenuUI.SetActive (false); // pause menu false
		m_musicMenuUI.SetActive (false); // music menu false

		Time.timeScale = 1; // time running again

		m_gameIsPaused = false; // game is not paused
	}

	// play track 1
	public void PlayTrack1(){

		m_audioSource.Stop (); // stop current track
		m_audioSource.PlayOneShot (m_track1); // play track
	}

	// play track 2
	public void PlayTrack2(){

		m_audioSource.Stop (); // stop current track
		m_audioSource.PlayOneShot (m_track2); // play track
	}

	// play track 3
	public void PlayTrack3(){

		m_audioSource.Stop (); // stop current track
		m_audioSource.PlayOneShot (m_track3); // play track
	}

	// play track 4
	public void PlayTrack4(){

		m_audioSource.Stop (); // stop current track
		m_audioSource.PlayOneShot (m_track4); // play track
	}
}