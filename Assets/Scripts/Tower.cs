using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	public GameObject bullet;
	public float rotation_speed = 35;
	public float fire_rate;
	private float next_fire;
	private List<GameObject> target_queue = new List<GameObject>();
	private bool in_range = false;
	private GameObject enemy;


	// Update is called once per frame
	void Update () {
		if (!enemy) {
			if (target_queue.Count > 0) {
				target_queue.RemoveAt (0);
			}
		}
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
			target_queue.Add (other.gameObject);
			//enemy = other.gameObject;
			enemy = target_queue[0];
			//enemy.GetComponent<Monster>().nav.speed = 1.0f;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Monster") {
			in_range = false;
			target_queue.RemoveAt (0);
			if (target_queue.Count > 0) {
				enemy = target_queue [0];
			}
			//other.gameObject.GetComponent<Monster>().nav.speed = 3.0f;
		}
	}
}
