using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		GameObject prize = GameObject.FindGameObjectWithTag ("Prize");

		if (prize) {
			GetComponent<NavMeshAgent> ().destination = prize.transform.position;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Prize") {
			other.GetComponentInChildren<Health> ().Decrease ();
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			Destroy (gameObject);
		}
	}
}
