using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speedX;
	public float speedY;
	private float moveHorizontal;
	public static bool collided;
	private AudioSource footstepsAudio;
	public Vector3[] positions;
	private int currPosition;

	void Awake() {

		if (footstepsAudio == null) {
			footstepsAudio = GetComponent<AudioSource> ();
		}
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		speedX = 20.0f;
		speedY = 5.0f;
		collided = false;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))  {
			currPosition--;  
			if (currPosition < 0) 
				currPosition = 0;
		}


		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d")) {
			currPosition++;
			if (currPosition >= positions.Length) 
				currPosition = positions.Length - 1;
		}
			
		transform.position = Vector3.MoveTowards(transform.position, positions[currPosition], Time.deltaTime * speedX);

	}

	public void MovePlayerLeftTouch() {
		currPosition--;  
		if (currPosition < 0) 
			currPosition = 0;
	}

	public void MovePlayerRightTouch() {
		currPosition++;
		if (currPosition >= positions.Length) 
			currPosition = positions.Length - 1;
	}

	public void PlayerToggle (bool b) {
		gameObject.SetActive (b);
	}

	public void MuteFootsteps(bool b) {
		footstepsAudio.mute = b;
	}

}
