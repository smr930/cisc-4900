/*
 * Play warning sound depending on the position of the obstacle
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWarning : MonoBehaviour {
	public AudioSource warningAudio;
	private Vector3 obstaclePosition;
	public GameObject warningInd;

	// Use this for initialization
	void Start () {
		if (warningAudio == null)
			warningAudio = GetComponent <AudioSource> ();

		obstaclePosition = transform.position;
		warningInd.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Indicate to the player when they are about to hit an obstacle
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {

			// Check where the obstacle is and play sound from that direction
			if (obstaclePosition.x == 0f)
				warningAudio.panStereo = 0; // center channel

			else if (obstaclePosition.x < 0f)
				warningAudio.panStereo = -1; // left channel

			else if (obstaclePosition.x > 0f)
				warningAudio.panStereo = 1; // center channel
			
			warningInd.SetActive (true);
			warningAudio.Play ();
			Debug.Log ("Warning! Player is about to hit an obstacle");

		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			warningInd.SetActive (false);
		}
	}
}
