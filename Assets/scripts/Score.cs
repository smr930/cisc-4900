using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static int collected = 0;
	public static int obstaclesHit = 0;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = collected.ToString();
	}
}
