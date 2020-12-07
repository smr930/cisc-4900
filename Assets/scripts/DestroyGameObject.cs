using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {
	public GameObject objToBeDestroyed;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {

			Destroy (objToBeDestroyed);
		}
	}

}
