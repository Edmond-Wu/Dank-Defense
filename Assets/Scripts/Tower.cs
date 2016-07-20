using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	public GameObject bullet;
	public float rotation_speed = 35;
	public float fire_rate;
	private float next_fire;
	private List<GameObject> target_queue = new List<GameObject>();
	private GameObject enemy;


	// Update is called once per frame
	void Update () {
		if (!enemy) {
			SwitchEnemy ();
		}
		transform.Rotate(Vector3.up * Time.deltaTime * rotation_speed, Space.World);
		if (Time.time > next_fire && enemy) {
			next_fire = Time.time + fire_rate;
			GameObject g = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			g.GetComponent<Bullet> ().target = enemy.transform;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Monster") {
			target_queue.Add (other.gameObject);
			//enemy = other.gameObject;
			enemy = target_queue[0];
			//enemy.GetComponent<Monster>().nav.speed = 1.0f;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Monster") {
			SwitchEnemy ();
			//other.gameObject.GetComponent<Monster>().nav.speed = 3.0f;
		}
	}

	void SwitchEnemy() {
		if (target_queue.Count > 0) {
			target_queue.RemoveAt (0);
			if (target_queue.Count > 0) {
				enemy = target_queue [0];
			}
		}
	}
}
