using UnityEngine;
using System.Collections;

public class MineSpawn : MonoBehaviour {

	bool has_mine = false;
	int cost = 20;
	Spawn spawn;
	GameObject mine;
	public GameObject mine_prefab;

	void Start () {
		GameObject spawn_obj = GameObject.FindWithTag ("Spawn");
		if (spawn_obj != null) {
			spawn = spawn_obj.GetComponent<Spawn> ();
		} 
		else {
			Debug.Log ("Cannot find 'Spawn' script");
		}
	}

	void OnMouseUpAsButton() {
		//if (!has_mine) {
			if (spawn.GetKash() < cost) {
				GetComponent<AudioSource> ().Play ();
			}
			else {
				mine = Instantiate (mine_prefab);
				Vector3 dir = new Vector3(0f, .1f, 0f);
				mine.transform.position = transform.position + dir;
				spawn.MakeKash (-cost);
				has_mine = true;
			}
		//}
	}
}
