using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] float speed = 1f;

	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * speed,Space.World);
		transform.Rotate(Vector3.forward, 360f * Time.deltaTime);
	}
}
