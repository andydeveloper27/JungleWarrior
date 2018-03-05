using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages when to play particle effect
public class DestroyHealthPickUp : MonoBehaviour {

	public HealthPickUp healthPickUp; // health pick up

	public ParticleSystem m_particleSystem; // particle system

	// Use this for initialization
	void Start () {

		m_particleSystem.Stop (); // makes sure particle system is not playing upon starting
	}
	
	// Update is called once per frame
	void Update () {

		// if health has been enabled
		if (healthPickUp.m_pickUpEnabled) {

			m_particleSystem.Play (); // play particle effect
		}
	}
}
