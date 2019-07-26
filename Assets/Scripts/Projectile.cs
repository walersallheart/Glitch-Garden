using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] float speed = 1f;
	[SerializeField] float damage = 50f;

	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * speed,Space.World);
		transform.Rotate(Vector3.forward, 360f * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D otherCollider) {
		Debug.Log("I hit:" + otherCollider.name);

		var health = otherCollider.GetComponent<Health>();
		var attacker = otherCollider.GetComponent<Attacker>();

		if (attacker && health) {
			health.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
