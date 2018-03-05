using UnityEngine;
using UnityEngine.UI;

// manages the score system
public class ScoreScript : MonoBehaviour {

	public int m_score; // score
	public Text m_scoreText; // score text

	public int m_scoreFinal; // final score
	public Text m_scoreFinalText; // final score text

	public EnemyCount enemycount; // enemy count
	public LevelComplete levelcomplete; // level complete
	public TimerScript timerscript; // timer script

	// Use this for initialization
	void Start () {

		m_scoreFinalText.enabled = false; // final text disabled
	}
	
	// Update is called once per frame
	void Update () {

		// score text set to score
		m_scoreText.GetComponent<Text> ().text = m_score.ToString ();

		//final text set to final score int
		m_scoreFinalText.GetComponent<Text> ().text = m_scoreFinal.ToString ();

		// when enemies remaining is 0 and level is complete
		if (enemycount.m_enemiesRemaining == 0 && levelcomplete.m_levelIsComplete) {

			m_scoreFinal = m_score * timerscript.m_timer; // final score is score * the current time

			m_scoreFinalText.enabled = true; // enables final score text
		}
	}
}