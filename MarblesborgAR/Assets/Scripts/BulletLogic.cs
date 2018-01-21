using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour {

	public float Damage = 10f;


	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<NPC> ().DecreaseHealth (Damage);
			col.gameObject.GetComponent<AudioSource>().Play();
		} 
	}
}
