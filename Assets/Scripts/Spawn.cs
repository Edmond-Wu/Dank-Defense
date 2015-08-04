using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject monster;
	public float time_between_spawns = 3;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnNext", time_between_spawns, time_between_spawns);
	}

	void SpawnNext() {
		Instantiate(monster, transform.position, Quaternion.identity);
	}
}
