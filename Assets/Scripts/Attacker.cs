using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	float currentSpeed = 1f;

	GameObject currentTarget;

	public void SetMovementSpeed(float speed){
		currentSpeed = speed;
	}

	void Update () {
		transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
		UpdateAnimationState();
	}

	private void UpdateAnimationState(){
		if (!currentTarget){
			GetComponent<Animator>().SetBool("isAttacking",false);
		}
	}

	public void Attack(GameObject target){
		GetComponent<Animator>().SetBool("isAttacking",true);
		currentTarget = target;
	}

	public void StrikeCurrentTarget(float damage){
		if (!currentTarget){
			return;
		}

		Health health = currentTarget.GetComponent<Health>();

		if (health) {
			health.DealDamage(damage);
		}
	}
}
