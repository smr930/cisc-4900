using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour {

	public GameObject PrefabToSpawn;
	public float spawnRate;
	public float startIn;

	// Use this for initialization
	void Start () {
		//Invoke ("SpawnSubLevel", 0);
		InvokeRepeating ("SpawnAPrefab", startIn, spawnRate);

	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnAPrefab() {
		// instantiate a block of the level
		GameObject prefab = (GameObject)Instantiate (PrefabToSpawn);
		prefab.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);

	}
}
