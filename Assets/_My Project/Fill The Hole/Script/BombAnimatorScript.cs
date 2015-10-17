using UnityEngine;
using System.Collections;

public class BombAnimatorScript : MonoBehaviour {

	private Animator animator;
	
	public bool IsOpen{
		get{return animator.GetBool("IsOpen");}
		set{animator.SetBool("IsOpen",value);}
	}
	
	public void Awake(){
		animator = GetComponent<Animator> ();
	}
	


}
