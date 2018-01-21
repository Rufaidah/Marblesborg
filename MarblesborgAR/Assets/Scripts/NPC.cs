using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

	public float Health;
	public float maxHealth;
	public float Damage = 5f;
	public float speed = 5f;
	public float attackSpeed = 3;
	public float currentAttackSpeed;
	public Image HealthBar;

	public GameObject Target;

	void Start(){
		maxHealth = Health;

		HealthBar.fillAmount = Health / maxHealth;
		Target = GameplayManager.instance.Tower.gameObject;
		currentAttackSpeed = 0;
	}


	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, Target.transform.position) > 0.3f) {
			transform.LookAt (Target.transform.position);
			transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, speed * Time.deltaTime);
		} else {
			if (currentAttackSpeed >= attackSpeed) {
				GameplayManager.instance.DecreaseHealth (Damage);
				currentAttackSpeed = 0;
			} else {
				currentAttackSpeed += Time.deltaTime;
			}
		}
	}

	public void DecreaseHealth(float _damage){
		Health -= _damage;
		HealthBar.fillAmount = Health / maxHealth;

		if (Health <= 0) {
			Destroy (gameObject);
		}
	}
}
