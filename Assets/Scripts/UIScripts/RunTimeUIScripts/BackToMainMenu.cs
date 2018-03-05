using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// manages back to main menu button
public class BackToMainMenu : MonoBehaviour {

	public PlayerHealth playerhealth; // playerhealth

	public Canvas m_backToMainMenu; // back to main menu canvas

	// Use this for initialization
	void Start () {

		m_backToMainMenu.enabled = false; // canvas not enabled
	}
	
	// Update is called once per frame
	void Update () {

		// when health is 0
		if (playerhealth.m_health == 0) {

			m_backToMainMenu.enabled = true; // back to main menu canvas enabled
		}
	}

	// back to main menu button function
	public void BackToMainMenuButton(){

		SceneManager.LoadScene ("MainMenu"); // load main menu
	}

	// restart level button function
	public void RestartLevel(){

		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // load current level again
	}
}
