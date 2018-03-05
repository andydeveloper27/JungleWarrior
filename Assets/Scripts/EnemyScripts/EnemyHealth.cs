﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages enemy health and when enemy has died
public class EnemyHealth : MonoBehaviour {

	public EnemyDestroyed enemyDestroyed; // enemy destroyed
	public EnemyCount enemycount; // enemy count
	public ScoreScript scorescript; // score script

	public float m_enemyHealth; // enemy health

	public bool m_enemyDied; // has enemy died bool

	public PlayerShooting playerShooting; // player shooting

	// Use this for initialization
	void Start () {

		m_enemyDied = false; // enemy has not died

		m_enemyHealth = 20f; // health set to 20f
	}
	
	// Update is called once per frame
	void Update () {

		// keeps the destroyed enemy particle system in the enemies position at all times
		enemyDestroyed.transform.position = gameObject.transform.position; 
	}

	// takes damage from enemie's health
	public void TakeDamage(float amount){

		m_enemyHealth -= amount; // takes amount from current health

		// if enemy health is 0
		if (m_enemyHealth <= 0) {

			Die (); // enemy has died
		}
	}

	// manages when Enemy has died
	void Die(){

		m_enemyDied = true; // enemy has died

		enemycount.m_enemiesRemaining--; // enemy count decreased

		scorescript.m_score += 10; // score increase

		Destroy (gameObject); // destroys enemy
	}
}