using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void restartBtn(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
