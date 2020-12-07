﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {

			int scene = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
			Debug.Log ("Level Restarted!");

		}
	}
}
