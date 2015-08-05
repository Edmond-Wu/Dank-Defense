using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public GameObject bullet;
	public float rotation_speed = 35;
	public float fire_rate;
	private float next_fire;
	private bool in_range = false;
	private GameObject monster;
	private int upgrade_cost = 20;
	private Spawn spawn;

	void Start () {
		GameObject spawn_obj = GameObject.FindWithTag ("Spawn");
		if (spawn_obj != null) {
			spawn = spawn_obj.GetComponent<Spawn> ();
		} 
		else {
			Debug.Log ("Cannot find 'Spawn' script");
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotation_speed, Space.World);
		if (Time.time > next_fire && in_range && monster) {
			next_fire = Time.time + fire_rate;
			GameObject g = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			g.GetComponent<Bullet> ().target = monster.transform;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Monster") {
			in_range = true;
			monster = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Monster") {
			in_range = false;
		}
	}
}
