/*
 * Spawn level block as player gets close
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextBlock : MonoBehaviour {

	public GameObject blockPrefab;
	public float x, y;
	private int offset = 1;
	public static int spawnCount = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// On collision, spawn a block
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player") && spawnCount < 2) {
			SpawnBlockLevel ();
			Debug.Log ("Spawning next block");
			//offset++;
		}
	}

	void SpawnBlockLevel() {
		// instantiate a block of the level
		GameObject level = (GameObject)Instantiate (blockPrefab);
		level.transform.position = new Vector2 (x, y * offset);
		offset++;
		spawnCount++;
	}
}
