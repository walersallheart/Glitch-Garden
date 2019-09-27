﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	[SerializeField] GameObject winLabel;

	[SerializeField] float waitToLoad = 4f;

	int numberOfAttackers = 0;
	bool levelTimerFinished = false;

	private void Start() {
		winLabel.SetActive(false);
	}

	public void AttackerSpawned(){
		numberOfAttackers++;
	}

	public void AttackerKilled(){
		numberOfAttackers--;

		if (numberOfAttackers <= 0 && levelTimerFinished) {
			StartCoroutine(HandleWinCondition());
		}
	}

	IEnumerator HandleWinCondition(){
		winLabel.SetActive(true);

		GetComponent<AudioSource>().Play();

		yield return new WaitForSeconds(waitToLoad);

		FindObjectOfType<LevelLoader>().LoadNextScene();
	}

	public void LevelTimerFinished(){
		levelTimerFinished = true;
		StopSpawners();
	}

	public void StopSpawners(){
		AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

		foreach (AttackerSpawner spawner in spawnerArray)
		{
			spawner.StopSpawning();
		}
	}
}
