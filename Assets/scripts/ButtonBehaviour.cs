/*
 * Handle button behaviour with variables and methods.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {
	public PlayerController player;

	public GameObject[] DisplayWhenPaused;
	public GameObject[] DisplayWhenResumed;
	public static bool paused;
	public GameObject EndOfLevelGameObject;
	public Text scoreText;
	public Button restartLevelButton;
	public AudioSource pauseAudio;
	public AudioSource resumeAudio;
	public AudioSource levelMusic;

	public Image controls1;
	public Image controls2;


	public GameObject[] DisplayWhenclickingSettings;
	public GameObject[] HideWhenclickingSettings;


	// Use this for initialization
	void Start () {
		EndOfLevelGameObject.gameObject.SetActive (false);
		player = player.GetComponent<PlayerController> ();

		if (pauseAudio == null)
			pauseAudio = GetComponent <AudioSource> ();
		if (resumeAudio == null)
			resumeAudio = GetComponent <AudioSource> ();
		if (levelMusic == null)
			levelMusic = GetComponent <AudioSource> ();

		controls1 = controls1.GetComponent<Image>();
		controls2 = controls2.GetComponent<Image>();

		GameController.instance.LoadControlSize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !paused)
			PauseGame ();

		else if (Input.GetKeyDown (KeyCode.Escape) && paused)
			ResumeGame ();

		if (EndOfLevelController.isEndOfLevel == true) {
			scoreText.text = Score.collected.ToString ();
			player.PlayerToggle (false);
			EndOfLevelGameObject.gameObject.SetActive (true);
		}
	}

	public void MovePlayerLeft() {
		player.MovePlayerLeftTouch ();
	}

	public void MovePlayerRight() {
		player.MovePlayerRightTouch ();
	}

	public void PauseGame() {
		pauseAudio.Play ();
		paused = true;
		Time.timeScale = 0.0f;
		player.MuteFootsteps (true);
		levelMusic.Pause ();

		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (true);
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (false);
	}

	public void ResumeGame() {
		resumeAudio.Play ();
		paused = false;
		Time.timeScale = 1.0f;
		player.MuteFootsteps (false);
		levelMusic.Play ();

		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (false);
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);

	}

	public void QuitGame () {
		Application.Quit();
	}

	public void RestartLevel() {
		player.PlayerToggle (true);
		Score.collected = 0;
		GameController.instance.playerSpeed = 8;
		ResumeGame ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void LoadScene (string str) {
		player.PlayerToggle (true);
		Score.collected = 0;
		GameController.instance.playerSpeed = 8;
		ResumeGame ();
		SceneManager.LoadScene (str);
	}

	public void LoadSceneFromMainMenu (string str) {
		SceneManager.LoadScene (str);
	}

	public void ReturnToMainMenu () {
		GameController.instance.playerSpeed = 8;
		Score.collected = 0;
		SceneManager.LoadScene ("MainMenu");
	}

	// overlay controls for touch-enabled devices
	public void ShowControls () {
		if (GameController.instance.toggleControls == true) { 
			Color c = controls1.color;
			c.a = 0.20f;
			controls1.color = c;
			controls2.color = c;
			GameController.instance.toggleControls = false;
		} else { // hide controls
			Color c = controls1.color;
			c.a = 0f;
			controls1.color = c;
			controls2.color = c;
			GameController.instance.toggleControls = true;
		}
	}

	public void ChangeControlSize (float size) {
		controls1.transform.localScale = new Vector3 (size, size, 0);		
		controls2.transform.localScale = new Vector3 (size, size, 0);
		GameController.instance.controlSize = size;
	}

	public void Settings () {
		foreach (GameObject dp in DisplayWhenclickingSettings)
			dp.SetActive (true);
		foreach (GameObject dp in HideWhenclickingSettings)
			dp.SetActive (false);
	}

	public void BackFromSettings () {
		foreach (GameObject dp in DisplayWhenclickingSettings)
			dp.SetActive (false);
		foreach (GameObject dp in HideWhenclickingSettings)
			dp.SetActive (true);
	}

	public void MuteAudio() {
		if (AudioListener.volume == 0)
			AudioListener.volume = 1;
		else
			AudioListener.volume = 0;
	}

	public void MuteMusic() {
		if (GameController.instance.muteMusic == true) {
			levelMusic.mute = false;
			GameController.instance.muteMusic = false;
		} else {
			levelMusic.mute = true;
			GameController.instance.muteMusic = true;
		}	
	}
}
