/*
 * When the level ends, show stats screen
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelController : MonoBehaviour {
	public static bool isEndOfLevel;
	public GameObject scoreOverlay;
	public SpriteRenderer overlay;
	public PlayerController player;
	public GameObject pauseButton;
	public GameObject health;

	// Use this for initialization
	void Start () {
		isEndOfLevel = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			scoreOverlay.SetActive (false);
			pauseButton.SetActive (false);
			health.SetActive (false);
			isEndOfLevel = true;
			player.GetComponent<PlayerController> ().MuteFootsteps (true);
			StartCoroutine (FadeToBlack());
		}
	}

	// Fade to black before loading the next scene
	public IEnumerator FadeToBlack() {
		overlay.gameObject.SetActive (true);
		overlay.color = Color.clear;

		float rate = 1.0f / 1.5f;
		float progress = 0.0f;

		while (progress < 1.0f) {
			overlay.color = Color.Lerp (Color.clear, Color.black, progress);
			progress += rate * Time.deltaTime;
			yield return null;
		}

		overlay.color = Color.black;
	}
}
