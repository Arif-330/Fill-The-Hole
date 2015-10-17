using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour {

	public Camera cam ;
	private float maxWidth;

	void Start(){
		if (cam==null) {
			cam=Camera.main;
		}

		Vector3 upperCorner = new Vector3 (Screen.width,Screen.height,0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float hatWidth = this.GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;
	}

	//Update is callled once per Physics timestep
	void FixedUpdate(){
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, this.GetComponent<Transform>().position.y, 0f);
		float targetWidth = Mathf.Clamp (targetPosition.x,-maxWidth,maxWidth);
		targetPosition = new Vector3 (targetWidth,targetPosition.y,0f);
		this.GetComponent<Rigidbody2D> ().MovePosition (targetPosition);
	}
}
