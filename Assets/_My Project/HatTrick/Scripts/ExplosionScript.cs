/// <summary>
/// Explosion script.is attached to Bomb;
/// </summary>

using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {
	public GameObject explosion;
	public ParticleSystem[] effects;

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log ("amar hiyar majhe lukiye chile");
		if (collision.gameObject.name=="Hat") {
			Instantiate(explosion,this.transform.position,this.transform.rotation);
			foreach (var effect in effects) {
				effect.transform.parent=null;
				effect.Stop();
				Destroy(effect.gameObject,1f);
			}
			Destroy(gameObject);
		}
	}

}
