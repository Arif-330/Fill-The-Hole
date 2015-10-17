/// <summary>
/// Game controller.is attached to GameController
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Camera cam;
	public GameObject ball;
	public GameObject bomb;
	private float maxWidth;
	public float timeLeft=10f;
	public Text timeLeftText;
	public GameObject gameOverText;
	public GameObject restartBtn;

	void Start(){
		if (cam==null) {
			cam=Camera.main;
		}

		Vector3 upperCorner = new Vector3 (Screen.width,Screen.height,0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = ball.GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		StartCoroutine ("Spawn");
		updateText ();
		/*particleFlare.GetComponent<Renderer> ().sortingLayerName = "Foreground";
		GameObject particleSmoke = particleFlare.transform.GetChild (0).gameObject as GameObject;
		particleSmoke.GetComponent<Renderer> ().sortingLayerName = "Foreground";
		GameObject particleSpark=particleFlare.transform.GetChild(1).gameObject as GameObject;
		particleSpark.GetComponent<Renderer> ().sortingLayerName = "Foreground";*/

	}

	void FixedUpdate(){
		timeLeft -= Time.deltaTime;
		if (timeLeft<0) {
			timeLeft=0;
		}
		updateText ();
	}
	private void updateText(){
		timeLeftText.text = "Time Left :\n" + Mathf.RoundToInt (timeLeft);
	}
	IEnumerator Spawn(){
		while (timeLeft>0) {

			Vector3 spawnPosition = new Vector3 (
			Random.Range (- maxWidth, maxWidth),
			ball.transform.position.y,
			0f
			);
			Quaternion spawnRotation = Quaternion.identity;
			if (Random.value<.5f) {
				Instantiate (ball, spawnPosition, spawnRotation);
			}else{
				Instantiate (bomb, spawnPosition, spawnRotation);
			}


			yield return new WaitForSeconds (1.5f);

		}
		//yield return new WaitForSeconds(2f);
		gameOverText.SetActive (true);
		//yield return new WaitForSeconds(2f);
		restartBtn.SetActive (true);
	}

}
