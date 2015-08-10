using UnityEngine;
using System.Collections;

public class Construction : MonoBehaviour {
	GameObject tower; //= tower_prefab;
	public GameObject tower_prefab;
	public GameObject upgrade_prefab;
	private Spawn spawn;
	private int cost = 25;
	private int upgrade_cost = 20;
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
				tower = Instantiate (tower_prefab);
				tower.transform.position = transform.position + Vector3.up;
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
					GameObject upgrade = (GameObject)Instantiate (upgrade_prefab);
					upgrade.transform.position = transform.position + Vector3.up;
					spawn.MakeKash (-upgrade_cost);
					upgraded = true;
				}
			}
		}
	}
}
