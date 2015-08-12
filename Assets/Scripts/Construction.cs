using UnityEngine;
using System.Collections;

public class Construction : MonoBehaviour {
	GameObject tower;
	public GameObject tower_prefab;
	public GameObject upgrade_prefab;
	private Spawn spawn;
	private int cost = 20;
	private int upgrade_cost = 40;
	private bool has_tower = false;
	private bool upgraded = false;

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
		if (!has_tower) {
			if (spawn.GetKash() < cost) {
				GetComponent<AudioSource> ().Play ();
			}
			else {
				tower = (GameObject)Instantiate (tower_prefab, transform.position + Vector3.up, Quaternion.identity);
				spawn.MakeKash (-cost);
				has_tower = true;
			}
		} else {
			if (!upgraded) {
				if (spawn.GetKash() < upgrade_cost) {
					GetComponent<AudioSource> ().Play ();
				}
				else {
					Destroy(tower);
					tower = (GameObject)Instantiate (upgrade_prefab, transform.position + Vector3.up, Quaternion.identity);
					spawn.MakeKash (-upgrade_cost);
					upgraded = true;
				}
			}
		}
	}
}
