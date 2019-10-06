﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	[SerializeField] GameObject projectile, gun;

	AttackerSpawner myLaneSpawner;

	Animator animator;
	GameObject projectileParent;
	const string PROJECTILE_PARENT_NAME = "Projectiles";

	private void Start() {
		animator = GetComponent<Animator>();
		CreateProjectileParent();
		SetLaneSpawner();
	}

	public void CreateProjectileParent(){
		projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

		if (!projectileParent) {
			projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
		}
	}

	private void Update() {
		if (IsAttackerInLane()){
			animator.SetBool("IsAttacking",true);
		} else {
			animator.SetBool("IsAttacking",false);
		}
	}

	private void SetLaneSpawner(){
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

		foreach (AttackerSpawner spawner in spawners)
		{
			bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

			if (IsCloseEnough) {
				myLaneSpawner = spawner;
			}
		}
	}

	private bool IsAttackerInLane(){
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		return true;
	}

	public void Fire(){
		GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;
		newProjectile .transform.parent = projectileParent.transform;
	}
}
