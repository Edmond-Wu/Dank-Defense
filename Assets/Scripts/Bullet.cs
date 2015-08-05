using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 15;
	public Transform target;
	public int damage = 1;

	void FixedUpdate() {
		if (target) {
			Vector3 direction = target.position - transform.position;
			GetComponent<Rigidbody> ().velocity = direction.normalized * speed;
		} else {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		Health health = other.GetComponentInChildren<Health>();
		if (health) {
			for (int i = 0; i < damage; i++) {
				health.Decrease();
			}
			Destroy(gameObject);
		}
	}
}
