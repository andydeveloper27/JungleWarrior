using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when enemy has been destroyed, this particle system is played in the enemies death location
public class EnemyDestroyed : MonoBehaviour {

	public EnemyHealth enemyHealth; // enemy health

	public ParticleSystem m_particleSystem; // particle system

	// Use this for initialization
	void Start () {

		m_particleSystem.Stop (); // makes sure the particle systemn is not playing at start
	}
	
	// Update is called once per frame
	void Update () {

		// if enemy has died
		if (enemyHealth.m_enemyDied) {

			m_particleSystem.Play (); // play particle system
		}
	}
}
