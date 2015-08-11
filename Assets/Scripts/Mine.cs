using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject explosion;
	Spawn spawn;

	void Start () {
		GameObject spawn_obj = GameObject.FindWithTag ("Spawn");
		if (spawn_obj != null) {
			spawn = spawn_obj.GetComponent<Spawn> ();
		} 
		else {
			Debug.Log ("Cannot find 'Spawn' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		Instantiate (explosion, other.transform.position, other.transform.rotation);
		Destroy (gameObject);
		spawn.MakeKash (1);
		spawn.AddPoints (1);
	}
}
