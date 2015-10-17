using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonListenerScript : MonoBehaviour {

	public Button PlayBtn;
	public Text ScoreText;

	public void playBtnListener(){

		//ScoreText.GetComponent<Renderer>().material.color=new Color (1,1,1,0);

		PlayBtn.gameObject.SetActive(false);
		StaticVarScript.canPlay = true;
		//PlayBtn.GetComponent<Renderer>().material.color= new Color (1,1,1,0);

		ScoreText.text="Score : 0";
	}
}
