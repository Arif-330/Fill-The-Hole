using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeCheckerScript : MonoBehaviour {

	public Button PlayBtn;
	public Text ScoreText;
	int score=0;
	void OnTriggerEnter2D(Collider2D other){

		GameObject passedBlock = other.gameObject;
		Debug.Log ("other gameobject tag : : "+passedBlock.tag);
		if (passedBlock.tag == "MovedOnce"||passedBlock.tag == "BlockBody") {



			//ScoreText.GetComponent<Renderer>().material.color=new Color (1,1,1,1);

			score = 0;
			StaticVarScript.canPlay = false;
			PlayBtn.gameObject.SetActive (true);

		} else if (passedBlock.tag == "AllowedBlock") {
			score += 1;
			//Debug.Log ("Score : "+score);
			ScoreText.text = "Score : " + score;
		} else {
			
		}

	}


}
