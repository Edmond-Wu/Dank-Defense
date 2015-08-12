using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public GameObject bullet;
	public float rotation_speed = 35;
	public float fire_rate;
	private float next_fire;
	private bool in_range = false;
	private GameObject enemy;


	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotation_speed, Space.World);
		if (Time.time > next_fire && in_range && enemy) {
			next_fire = Time.time + fire_rate;
			GameObject g = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			g.GetComponent<Bullet> ().target = enemy.transform;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Monster") {
			in_range = true;
			enemy = other.gameObject;
			//enemy.GetComponent<Monster>().nav.speed = 1.0f;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Monster") {
			in_range = false;
			//other.gameObject.GetComponent<Monster>().nav.speed = 3.0f;
		}
	}
}
