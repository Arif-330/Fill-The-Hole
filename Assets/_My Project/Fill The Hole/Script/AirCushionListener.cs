/// <summary>
/// Air cushion listener.is attached to two Air Cushions 
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirCushionListener : MonoBehaviour {

	void OnTouchBegan(bool isBothCushionPressed){

		GameObject[] objects = GameObject.FindGameObjectsWithTag ("BlockBody");

		if (objects.Length>0) {

			//deathzone starting from cushions y plus half of  blocks height
			float deathZoneStartY = transform.position.y +(objects[0].transform.GetChild(0).GetComponent<Renderer>().bounds.size.y/2 );
			float deathZoneEndY=transform.position.y - (objects[0].transform.GetChild(0).GetComponent<Renderer>().bounds.size.y/2 );

			foreach (GameObject gameObject  in objects) {
				//Debug.Log ("Gameobjects number "+objects.Length);

				float Y=gameObject.transform.position.y;
				Transform blockBody=gameObject.transform;
				Transform bombBody=blockBody.GetChild(0).transform.GetChild(1).transform;
				Animator bombAnimator=bombBody.GetChild(0).GetComponent<Animator>();

				if (Y <deathZoneStartY && Y>deathZoneEndY) {

					if(isBothCushionPressed){

						if (bombBody.tag=="BBL_M") {

							blockBody.tag="AllowedBlock";
							bombAnimator.Play ("BombL_M");
							
						}else if(bombBody.tag == "BBR_M"){

							blockBody.tag="AllowedBlock";
							bombAnimator.Play ("BombR_M");

						}else if (bombBody.tag=="BBL_R") {

							blockBody.tag="MovedOnce";
							bombAnimator.Play ("BombL_M");

						}else if (bombBody.tag=="BBR_L") {

							blockBody.tag="MovedOnce";
							bombAnimator.Play ("BombR_M");
						}

						//Debug.Log("both button pressed ;");
						//bombAnimator.Play ("BombM_L");
					}else if (transform.name =="AirCushionRight") {

						if (bombBody.tag=="BBR_L") {

							blockBody.tag="AllowedBlock";
							bombAnimator.Play ("BombR_L");

						}else if (bombBody.tag=="BBR_M") {
							blockBody.tag="MovedOnce";
							bombAnimator.Play ("BombR_L");
						}

						Debug.Log(" button pressed ;"+transform.name);


					}else{
						if (bombBody.tag=="BBL_R") {

							blockBody.tag="AllowedBlock";
							bombAnimator.Play ("BombL_R");
							
						}else if (bombBody.tag=="BBL_M") {

							blockBody.tag="MovedOnce";
							bombAnimator.Play ("BombL_R");
						}
						Debug.Log(" button pressed ;"+transform.name);

					}

				}
			}

		}

	}

	void OnTouchEnded(){

	}
}
