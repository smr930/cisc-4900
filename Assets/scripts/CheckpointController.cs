/*
 * Restore player's health when activated
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {
	public Health health;
	public AudioSource checkpointAudio;

	// Use this for initialization
	void Start () {
		if (checkpointAudio == null)
			checkpointAudio = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			checkpointAudio.Play ();
			health.GetComponent<Health> ().SetCurrentHealth (100);
			health.GetComponent<Health> ().ShowHealth ();
		}
	}
}
