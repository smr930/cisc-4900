using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLevelSpawner : MonoBehaviour {

	public GameObject subLevel;
	public float spawnRate;
	public float startIn;
	public float x, y;

	// Use this for initialization
	void Start () {
		//Invoke ("SpawnSubLevel", 0);
		InvokeRepeating ("SpawnSubLevel", startIn, spawnRate);

	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnSubLevel() {
		// instantiate a sub level
		GameObject level = (GameObject)Instantiate (subLevel);
		level.transform.position = new Vector2 (x, y);

	}


}
