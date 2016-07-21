using UnityEngine;
using System.Collections;

public class Construction : MonoBehaviour {
	GameObject tower;
	public GameObject tower_prefab;
	public GameObject upgrade_prefab;
	public GameObject max_prefab;
	public GameObject three_sixty_prefab;
	private Spawn spawn;
	private int cost = 20;
	private int upgrade_cost = 40;
	private int max_cost = 80;
	private bool has_tower = false;
	private bool upgraded = false;
	private bool maxed = false;

	void Start () {
		GameObject spawn_obj = GameObject.FindWithTag ("Spawn");
		if (spawn_obj != null) {
			spawn = spawn_obj.GetComponent<Spawn> ();
		} 
		else {
			Debug.Log ("Cannot find 'Spawn' script");
		}
	}

	public int GetCost() {
		return cost;
	}

	void OnMouseUpAsButton() {
		if (spawn.GetKash () >= 360) {
			if (tower) {
				Destroy (tower);
			}
			tower = (GameObject)Instantiate (three_sixty_prefab, transform.position + Vector3.up, Quaternion.Euler (45, 0, 45));
			tower.GetComponent<AudioSource> ().Play ();
			spawn.MakeKash (-360);
			has_tower = true;
			maxed = true;
		} else {
			if (!has_tower) {
				if (spawn.GetKash () < cost) {
					GetComponent<AudioSource> ().Play ();
				} else {
					tower = (GameObject)Instantiate (tower_prefab, transform.position + Vector3.up, Quaternion.Euler (45, 0, 45));
					spawn.MakeKash (-cost);
					has_tower = true;
				}
			} else {
				Upgrade ();
			}
		}
	}

	void Upgrade() {
		if (!upgraded) {
			if (spawn.GetKash () < upgrade_cost) {
				GetComponent<AudioSource> ().Play ();
			} else {
				Destroy (tower);
				tower = (GameObject)Instantiate (upgrade_prefab, transform.position + Vector3.up, Quaternion.Euler(45, 0, 45));
				spawn.MakeKash (-upgrade_cost);
				upgraded = true;
			}
		} else {
			if (!maxed) {
				if (spawn.GetKash () < max_cost) {
					GetComponent<AudioSource> ().Play ();
				} else {
					Destroy (tower);
					tower = (GameObject)Instantiate (max_prefab, transform.position + Vector3.up, Quaternion.Euler(45, 0, 45));
					spawn.MakeKash (-max_cost);
					maxed = true;
				}
			}
		}
	}
}
