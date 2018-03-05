using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// manages main menu
public class MainMenu : MonoBehaviour {

	public Canvas m_levelSelectCanvas; // level select canvas
	public Canvas m_controlsCanvas; // controls canvas
	public Canvas m_mainMenuCanvas; // main menu canvas

	// Use this for initialization
	void Start () {

		m_mainMenuCanvas.enabled = true; // main menu enabled
		m_levelSelectCanvas.enabled = false; // level select not enabled
		m_controlsCanvas.enabled = false; // controls not enabled
	}
	
	// Update is called once per frame
	void Update () {

		Cursor.visible = true; // curose is visible
	}

	// plays the game
	public void PlayGame(){

		SceneManager.LoadScene ("Scene1"); // loads scene1
	}

	// level select
	public void LevelSelect(){

		m_mainMenuCanvas.enabled = false; // main menu canvas set to false
		m_levelSelectCanvas.enabled = true; // level select enabled
		m_controlsCanvas.enabled = false; // controls canvas disabled
	}

	// controls function
	public void Controls(){

		m_mainMenuCanvas.enabled = false; // main menu canvas set to false
		m_levelSelectCanvas.enabled = false; // level select canvas set to false
		m_controlsCanvas.enabled = true; // controls canvas set to false
	}

	// exit function
	public void Exit(){

		Application.Quit (); // quits application
	}

	public void BackToTheMainMenu(){

		m_mainMenuCanvas.enabled = true; // main menu enabled
		m_levelSelectCanvas.enabled = false; // level select not enabled
		m_controlsCanvas.enabled = false; // controls canvas not enabled
	}

	// loads scene 1
	public void LoadScene1(){

		SceneManager.LoadScene ("Scene1"); // loads scene 1
	}

	// loads scene2
	public void LoadScene2(){

		SceneManager.LoadScene ("Scene2"); // loads scene2
	}
}
