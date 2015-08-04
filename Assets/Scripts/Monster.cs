using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		GameObject prize = GameObject.Find ("Prize");

		if (prize) {
			GetComponent<NavMeshAgent> ().destination = prize.transform.position;
		}
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Prize") {
			c.GetComponentInChildren<Health> ().Decrease ();
			Instantiate (explosion, c.transform.position, c.transform.rotation);
			Destroy (gameObject);
		}
	}
}
