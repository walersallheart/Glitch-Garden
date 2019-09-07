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
	}

	public void Attack(GameObject target){
		GetComponent<Animator>().SetBool("isAttacking",true);
		currentTarget = target;
	}
}
