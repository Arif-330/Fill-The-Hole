/// <summary>
/// Game play.is attache to GamePlay
/// </summary>
using UnityEngine;
using System.Collections;

public class GamePlay : MonoBehaviour {

	public GameObject Block;
	private int life=1;
	private float blockGapTime=.75f;
	private Vector3 bombPos0=new Vector3(-0.478f,0f,0f);
	private Vector3 bombPos1=new Vector3(0f,0f,0f);
	private Vector3 bombPos2=new Vector3(0.531f,0f,0f);

	private bool isFirstTime=true;


	int countFrame=0;
	void Start(){

		//StartCoroutine (makeBlock());

	}

	void Update(){

		if (StaticVarScript.canPlay && isFirstTime) {
			life=1;
			isFirstTime=false ;
			StartCoroutine(makeBlock());

		}else if (!StaticVarScript.canPlay && !isFirstTime) {
			life=0;
			isFirstTime=true;
		}

		/*if (countFrame%20==0 && StaticVarScript.canPlay) {
			makeBlock ();
			countFrame=0;
		}

		countFrame += 1;*/

		//check at least half of current blocks that succesfully pass or not .if not , then die;  


	}

	//make the Block in loop after a time period 

	IEnumerator makeBlock(){
		if (life<1) {
			GameObject[] objects = GameObject.FindGameObjectsWithTag ("BlockBody");
			foreach (GameObject gameObject in objects) {
				Destroy(gameObject);
			}
			 objects = GameObject.FindGameObjectsWithTag ("MovedOnce");
			foreach (GameObject gameObject in objects) {
				Destroy(gameObject);
			}
			objects = GameObject.FindGameObjectsWithTag ("EmptyBlock");
			foreach (GameObject gameObject in objects) {
				Destroy(gameObject);
			}
			objects = GameObject.FindGameObjectsWithTag ("AllowedBlock");
			foreach (GameObject gameObject in objects) {
				Destroy(gameObject);
			}
			return true;
		}
		GameObject BlockInstance=Instantiate(Block,Block.transform.position,Quaternion.identity) as GameObject;



		Transform bombTransform = BlockInstance.transform.GetChild (0).transform.GetChild(1).transform ;
		Transform holeTransform=BlockInstance.transform.GetChild (0).transform.GetChild(0).transform ;

		//place bomb and hole in a random position on block 

		int randBombPos = Random.Range(0,3);
		int randHolePos = 0;
		switch (randBombPos) {

		case 0:
			//bombTransform.position.x=0f;

			//BlockInstance.transform.position=bombPos1;
			bombTransform.position=bombPos0;
			//randomly set hole pos and give a tag to bomb body
			randHolePos=Random.Range(1,3);

			if (randHolePos==1) {
				holeTransform.position=bombPos1;
				bombTransform.tag="BBL_M";

			}else{
				holeTransform.position=bombPos2;
				bombTransform.tag="BBL_R";
			}

			break;

		case 1:
			bombTransform.gameObject.SetActive(false);
			BlockInstance.transform.tag="EmptyBlock";	
			break;
		case 2:
			bombTransform.position=bombPos2;
			//randomly set hole pos and give a tag to bomb body
			randHolePos=Random.Range(0,2);
			
			if (randHolePos==0) {
				holeTransform.position=bombPos0;
				bombTransform.tag="BBR_L";
				
			}else{
				holeTransform.position=bombPos1;
				bombTransform.tag="BBR_M";
			}
			break;
		default:
			break;

		}
		//BlockInstance.transform.GetChild(1).transform.position=
		//float blockHeight = BlockInstance.GetComponent<Renderer> ().bounds.size.y;
		//rightAirCushionListener ();
		yield return new WaitForSeconds (blockGapTime);
		StartCoroutine (makeBlock());

	}




}
