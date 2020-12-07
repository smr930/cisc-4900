/*
 * Handle what happens when the player fails
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverController : MonoBehaviour {

	public GameObject gameOver;
	public SpriteRenderer overlay;
	public GameObject scoreOverlay;
	public GameObject pauseButton;
	public GameObject healthbar;
	public PlayerController player;
	public AudioSource gameOverAudio;
	public AudioSource levelMusic;

	// Use this for initialization
	void Start () {
		if (gameOverAudio == null)
			gameOverAudio = GetComponent <AudioSource> ();
		if (levelMusic == null)
			levelMusic = GetComponent <AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void GameOver () {
		scoreOverlay.SetActive (false);
		pauseButton.SetActive (false);
		healthbar.SetActive (false);
		player.GetComponent<PlayerController> ().MuteFootsteps (true);
		StartCoroutine (FadeToBlack());
		gameOver.SetActive (true);
		gameOverAudio.Play ();
		levelMusic.Stop ();
	}

	// Fade to black before showing gameover screen
	public IEnumerator FadeToBlack() {
		overlay.gameObject.SetActive (true);
		overlay.color = Color.clear;

		float rate = 1.0f / 0.8f; // 2nd value controls the duration
		float progress = 0.0f;

		while (progress < 1.0f) {
			overlay.color = Color.Lerp (Color.clear, Color.black, progress);
			progress += rate * Time.deltaTime;
			yield return null;
		}

		overlay.color = Color.black;
		Time.timeScale = 0.0f;
	}
}
