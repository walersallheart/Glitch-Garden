using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	[SerializeField] int starCost = 100;

	private StarDisplay starDisplay;

	private void Start() {
		starDisplay = FindObjectOfType<StarDisplay>();
	}

	public void AddStars(int amount){
		starDisplay.AddStars(amount);
	}
}
