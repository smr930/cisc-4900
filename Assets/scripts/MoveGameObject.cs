/*
 * Handle moving the gameworld around the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGameObject : MonoBehaviour {
	public bool moveLeft;
	public bool moveRight;
	public bool moveUp;
	public bool moveDown;
	public float speed;
	public bool allowInverseMovement;
	public float timeDelay;

	// Use this for initialization
	void Start () {
		speed = GameController.instance.playerSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveLeft)
			transform.Translate (Vector3.left * speed * Time.deltaTime, Space.World);
		else if (moveRight) {
			if (PlayerController.collided) {
				transform.Translate (Vector3.right * -speed * Time.deltaTime, Space.World);
				StartCoroutine (ToggleBool ());
			} else
				transform.Translate (Vector3.right * speed * Time.deltaTime, Space.World);
		} else if (moveUp)
			transform.Translate (Vector3.up * speed * Time.deltaTime, Space.World);
		else if (moveDown) {
			if (PlayerController.collided) {
				transform.Translate (Vector3.down * -speed * Time.deltaTime, Space.World);
				StartCoroutine (ToggleBool ());
			} else
				transform.Translate (Vector3.down * speed * Time.deltaTime, Space.World);
		}

		// for debug purposes
		if (Input.GetKeyDown (KeyCode.LeftShift) && GameController.instance.IsDebugging()) {
			speed = 20;
		} else 
			speed = GameController.instance.playerSpeed;

		}

	IEnumerator ToggleBool() {
		yield return new WaitForSeconds (timeDelay);
		PlayerController.collided = false;
	}
}
