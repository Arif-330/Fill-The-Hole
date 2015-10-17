/// <summary>
/// Touch input is attached to GamePlay 
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
public class TouchInput : MonoBehaviour {
	//public LayerMask touchInputMask;
	
	public Text textL;
	public Text textR;

	private bool isBothCushionPressed=false;
	void Update(){

		if (Input.touchCount > 0) {


			for (int i = 0; i < Input.touchCount; i++)
			{	
				Touch touch=Input.GetTouch(i);
				Vector2 ray=Camera.main.ScreenToWorldPoint(touch.position);

				RaycastHit2D hit=Physics2D.Raycast(ray,Vector2.zero);

				if (hit !=null && hit.collider!=null && hit.collider.gameObject.tag=="Cushion") {

					if (touch.phase==TouchPhase.Began) {




						if (Input.touchCount==2 && i==1) {
							Debug.Log("mairalicche "+hit.collider.gameObject.tag);
							//Debug.Log("name of firstobject[0] : "+touchList[0].name);
							//Debug.Log("Object name[1] : "+touchList[1].name);
							textL.text="both";
								isBothCushionPressed=true;
								hit.collider.gameObject.SendMessage("OnTouchBegan",isBothCushionPressed);
								//isBothCushionPressed=false;
							break;
								//isBothCushionPressed=false;
						}else if(Input.touchCount==1 && i==0){
							textL.text="waiting";
							isBothCushionPressed=false;
							StartCoroutine(waitToCheckBothPresing(.01f,hit.collider.gameObject));

						}


					}else if (touch.phase == TouchPhase.Stationary) {

					}else if (touch.phase == TouchPhase.Ended) {


						//Debug.Log("list clear");
						//hit.collider.gameObject.SendMessage("OnTouchEnded");
					}
				}else{
					break;
				}

			}

			//Array.Clear(objects,1,objects.Length);
		}

			/*foreach (GameObject gameObject  in touchesOld) {
				if (!touchList.Contains(gameObject)) {
					gameObject.SendMessage("OnTouchExit");
				}
			}*/

	}

	IEnumerator waitToCheckBothPresing(float time,GameObject gameObject){

		yield return new WaitForSeconds(time);
		if (!isBothCushionPressed) {
			textL.text="One";
			gameObject.SendMessage ("OnTouchBegan", isBothCushionPressed);
		} else {
			textL.text="false";
			isBothCushionPressed=false;
		}

		//Debug.Log("in waiting: ");

	}
}


