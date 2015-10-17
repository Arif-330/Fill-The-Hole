using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Scoring : MonoBehaviour {
	public Text scoreText;
	private int score=0;

	void Start(){
		updateScore ();
	}

	void OnTriggerEnter2D(){
		score += 1;
		updateScore ();
	}

	void updateScore(){
		scoreText.text = "Score :\n" + score;
	}

}
