/*
 * Make level blocks visible when the player reaches a trigger
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibility : MonoBehaviour {
	public GameObject levelBlock;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {

			levelBlock.SetActive (true);
		}
	}
}
