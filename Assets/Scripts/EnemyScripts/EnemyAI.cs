using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enemy AI class to manage enemy movement and detection
public class EnemyAI : MonoBehaviour {

	public Transform m_player; // player

	public Transform[] m_target; // targets for the enemy to patrol
	public float m_speed; // speed in which the enemy runs

	public bool m_attackingPlayer; // set to whether the enemy is attacking the player or not

	private int m_currentPos; // current position

	private float m_playerDistance; // distance from player
	private float m_attackRange; // attack range

	private Animator m_animator; // animator

	// start
	void Start(){
		
		m_attackRange = 20.0f; // attack range

		m_animator = GetComponent<Animator> (); // animator

		m_attackingPlayer = false; // enemy is not attacking player
	}

	// Update is called once per frame
	void Update () {

		m_playerDistance = Vector3.Distance (m_player.position, transform.position); // distance between enemy to player

		// when not attacking the player
		if (!m_attackingPlayer) {

			// when enemy has not reached target position
			if (transform.position != m_target [m_currentPos].position) {

				// makes sure the enemy is rotated in the correct direction
				Vector3 relativePos = m_target [m_currentPos].position - transform.position; // relativePos position
				Quaternion rotation = Quaternion.LookRotation (relativePos); // Quaternion rotation
				transform.rotation = rotation; // rotation

				// position is enemy moving towards target position
				Vector3 pos = Vector3.MoveTowards (transform.position, m_target [m_currentPos].position, m_speed * Time.deltaTime);

				// rigibody
				GetComponent<Rigidbody> ().MovePosition (pos);

			} else
				m_currentPos = (m_currentPos + 1) % m_target.Length; // current position is next target position
		}

		// when player's distance is less than or equal to attack range
		if (m_playerDistance <= m_attackRange) {

			m_animator.SetBool ("Run", false); // run animation set to false

			m_attackingPlayer = true; // attacking player set to true

			AttackPlayer (); // attack player
		}
	}

	// attack player
	private void AttackPlayer(){

		// makes sure the enemy is rotated in the correct direction
		Vector3 relativePos = m_player.position - transform.position; // relative position
		Quaternion rotation = Quaternion.LookRotation (relativePos); // Quaternion rotation
		transform.rotation = rotation; // roattion

		m_animator.SetBool ("Shoot", true); // shoot animation set to true
	}
}
