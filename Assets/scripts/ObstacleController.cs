/*
 * Handle collision between player and obstacles
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
	public AudioSource hitAudio;
	public SpriteRenderer obstacleSprite;
	public Health playerHealth;

	// Use this for initialization
	void Start () {
		if (hitAudio == null)
			hitAudio = GetComponent <AudioSource> ();

		obstacleSprite  = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Obstacle collision handling
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			hitAudio.Play ();
			Debug.Log ("Player collided with an obstacle");
			PlayerController.collided = true;
			playerHealth.DecreaseHealth ();
			playerHealth.ShowHealth ();
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			//PlayerController.collided = false;
		}
	}
		
}
