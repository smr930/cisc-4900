using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;   
	public float offset;

	// Use this for initialization
	void Start () {

	}

	// LateUpdate is called after Update each frame
	void LateUpdate () {

		transform.position = new Vector3(0, player.transform.position.y + offset, -10);
	}
}
