using UnityEngine;
using System.Collections;

public class Construction : MonoBehaviour {

	public GameObject tower_prefab;

	void OnMouseUpAsButton() {
		GameObject tower = (GameObject)Instantiate (tower_prefab);
		tower.transform.position = transform.position + Vector3.up;
	}
}
