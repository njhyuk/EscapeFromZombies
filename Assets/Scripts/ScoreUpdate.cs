using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

	Text ScoreLabel;

	// Use this for initialization
	void Start () {
		ScoreLabel = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreLabel.text = "Score : " + ScoreManager.score.ToString ();
	}
}
