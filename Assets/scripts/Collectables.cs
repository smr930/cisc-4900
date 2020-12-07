/*
 * Coins for the player to collect and increase score
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

	public AudioSource collectAudio;

	// Use this for initialization
	void Start () {
		if (collectAudio == null)
			collectAudio = GetComponent <AudioSource> ();
		
	}

	// Update is called once per frame
	void Update () {

	}
		
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Score.collected++;
			GetComponent<SpriteRenderer>().enabled = false;
			collectAudio.Play ();
			Debug.Log ("Item collected! -- " + Score.collected);
			Destroy (gameObject, .7f);
		}
	}
}
