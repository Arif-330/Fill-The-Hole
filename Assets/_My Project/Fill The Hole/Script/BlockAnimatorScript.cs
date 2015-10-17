using UnityEngine;
using System.Collections;

public class BlockAnimatorScript : MonoBehaviour {

	private Animator animator;

	public bool IsOpen{
		get{return animator.GetBool("IsOpen");}
		set{animator.SetBool("IsOpen",value);}
	}

	public void Awake(){
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("")) {
			
		}
	}
	public void animationFinished(){
		Destroy (this.gameObject);
	}


}
