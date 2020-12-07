/*
 * Keep this Gameobject loaded throughout the game and
 * help preserve and pass data to other Gameobjects
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public int scoreLevel01;
	public bool toggleControls = true; 
	public Image controlsL;
	public Image controlsR;
	public float controlSize = 2.0f;
	public Camera mainCamera;
	public float cameraSize = 28.0f;
	public bool muteMusic = false;

	public float playerSpeed = 8;
	bool debuggingGame = false; // Set this to false on final build

	void Awake() {

		// If an instance already exists, destroy this one
		if (instance != null)
			Destroy (this.gameObject);

		// Otherwise, make this the instance
		else
			instance = this;

		// Enable persistence across scenes
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		LoadControlSize ();

	}

	void Update () {
		if (playerSpeed < 20) 
		{
			if (ButtonBehaviour.paused == false && PlayerController.collided == false)
				playerSpeed += .003f; // slowly increase player speed as you advance the level
		}
		else
			playerSpeed = 20;
	}

	public bool IsDebugging() {
		return debuggingGame;
	}
		
	public void KeepScore (int level, int collected) {
		//switch (level) {
		//case 1:
			scoreLevel01 = collected;

		//}
	}
		
	public void LoadControlSize ()
	{
		float size = controlSize;
		controlsL.transform.localScale = new Vector3 (size, size, 0);		
		controlsR.transform.localScale = new Vector3 (size, size, 0);
	}

}
